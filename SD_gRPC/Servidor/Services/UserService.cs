using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Servidor.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly TeatroDbContext _context;

        public UserService(ILogger<UserService> logger, TeatroDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public override Task<Reply> CheckLogin(UserLogin request, ServerCallContext context)
        {
            var user = _context.Clients.Find(request.Name);
            if (user == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"O username {request.Name} não existe.",
                      IsOk = false
                  }
                );
            }
            if(request.Password != user.password)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"A password nao se encontra correta.",
                      IsOk = false
                  }
                );
            }
            return Task.FromResult(
                  new Reply()
                  {
                      Result = $"Sucesso.",
                      IsOk = true
                  }
                );
        }

        public override Task<UserModel> GetUserInfo(UserLookupModel request, ServerCallContext context)
        {
            UserModel output = new UserModel();
            var user = _context.Clients.Find(request.UserName);
            _logger.LogInformation("A enviar resposta do Cliente...");

            if (user != null)
            {
                output.Id = user.username;
                output.Password = user.password;
                //output.Bilhetes = user.bilhetes;
                output.ContaVirtual = user.contaVirtual;
            }

            return Task.FromResult(output);
        }

        public override Task<Reply> InsertUser(UserLogin request, ServerCallContext context)
        {
            var s = _context.Clients.Find(request.Name);

            if (s != null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"O Cliente {request.Name} já existe.",
                      IsOk = false
                  }
                );
            }
            var user = new Cliente()
            {
                username = request.Name.ToLower(),
                password = request.Password,
                contaVirtual = 0,
            };

            _logger.LogInformation("Inserir Cliente.");

            try
            {
                _context.Clients.Add(user);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Cliente {request.Name} foi inserido.",
                   IsOk = true
               }
            );
        }

        public override Task<Reply> DeleteUser(UserLookupModel request, ServerCallContext context)
        {
            var s = _context.Clients.Find(request.UserName);

            if (s == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"O Cliente com o ID {request.UserName} não foi encontrado.",
                      IsOk = false
                  }
                );
            }

            _logger.LogInformation("Eliminar Cliente");
            foreach(var c in _context.Recibos.Include(c => c.Bilhetes))
            {
                if(c.ClienteId == request.UserName)
                {
                    foreach(var d in c.Bilhetes)
                    {
                        d.Cliente = null;
                        d.ClienteId = null;
                        d.Recibo = null;
                        d.ReciboId = null;
                        d.visto = false;
                    }
                    c.Cliente = null;
                    c.ClienteId = null;
                    _context.Recibos.Remove(c);
                }
            }

            try
            {
                _context.Clients.Remove(s);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Cliente com o ID {request.UserName} foi eliminado.",
                   IsOk = true
               }
            );
        }

        public override Task<Empty> AddFundos(UserFundos request, ServerCallContext context)
        {
            var s = _context.Clients.Find(request.UserName);
            s.contaVirtual += request.FundosAdicionar;
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }
        
        public override Task<UserList> RetrieveAllUsers(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos os Utilizadores: ");

            UserList list = new UserList();

            try
            {
                List<UserModel> userList = new List<UserModel>();

                var students = _context.Clients.ToList();

                foreach (var c in students)
                {
                    userList.Add(new UserModel()
                    {
                        Id = c.username,
                        Password = c.password,
                        ContaVirtual = c.contaVirtual,
                    });
                }

                list.Items.AddRange(userList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }


        public override Task<espetaculo> GetEspetaculoInfo(EspetaculoLookupModel request, ServerCallContext context)
        {
            espetaculo output = new espetaculo();
            output.Teatros = new teatro();
            var espetaculo = _context.Espetaculs.Include(x =>x.teatros).FirstOrDefault(x => x.id == request.EspetaculoId);
            _logger.LogInformation("A enviar resposta do Espetaculo...");

            if (espetaculo != null)
            {
                output.Id = espetaculo.id;
                output.Nome = espetaculo.nome;
                output.Sinopse = espetaculo.sinopse;
                output.Teatros.Id = espetaculo.teatros.id;
                output.DataInicio = espetaculo.dataInicio;
                output.DataFim = espetaculo.dataFim;
                output.Preco = espetaculo.preco;
            }

            return Task.FromResult(output);
        }

        public override Task<Reply> InsertEspetaculo(Addespetaculo request, ServerCallContext context)
        {
            var espetaculo = new Espetaculo()
            {
                nome = request.Nome,
                sinopse = request.Sinopse,
                TeatroId = request.Teatros.Id,
                dataInicio = request.DataInicio,
                dataFim = request.DataFim,
                preco = request.Preco,
            };

            _logger.LogInformation("Inserir Espetáculo.");

            try
            {
                _context.Espetaculs.Add(espetaculo);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Espetáculo {request.Nome} foi inserido.",
                   IsOk = true
               }
            );
        }

        public override Task<Reply> UpdateEspetaculo(espetaculo request, ServerCallContext context)
        {
            var s = _context.Espetaculs.Include(x => x.teatros).FirstOrDefault(x => x.id == request.Id);

            if (s == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"O Espetáculo {request.Nome} com o ID {request.Id} não foi encontrado.",
                      IsOk = false
                  }
                );
            }

            s.nome = request.Nome;
            s.sinopse = request.Sinopse;
            s.TeatroId = request.Teatros.Id;
            s.dataInicio = request.DataInicio;
            s.dataFim = request.DataFim;
            s.preco = request.Preco;

            _logger.LogInformation("Atualizar Espetáculo.");

            try
            {
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Espetáculo {request.Nome} com o ID {request.Id} foi atualizado.",
                   IsOk = true
               }
            );
        }

        public override Task<EspetaculoList> RetrieveAllEspetaculos(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos os Espetáculos: ");

            EspetaculoList list = new EspetaculoList();
            

            try
            {
                List<espetaculo> espetaculoList = new List<espetaculo>();

                var espetaculs = _context.Espetaculs.Include(x => x.teatros).ToList();

                foreach (var c in espetaculs)
                {
                    espetaculo esp = new espetaculo();
                    esp.Teatros = new teatro();
                    esp.Id = c.id;
                    esp.Nome = c.nome;
                    esp.Sinopse = c.sinopse;
                    esp.Teatros.Id = c.teatros.id;
                    esp.DataInicio = c.dataInicio;
                    esp.DataFim = c.dataFim;
                    esp.Preco = c.preco;

                    espetaculoList.Add(esp);
                }

                list.Items.AddRange(espetaculoList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }


        public override Task<teatro> GetTeatroInfo(TeatroLookupModel request, ServerCallContext context)
        {
            teatro output = new teatro();
            var teatro = _context.Teatrs.Find(request.TeatroId);
            _logger.LogInformation("A enviar resposta do Teatro...");

            if (teatro != null)
            {
                output.Id = teatro.id;
                output.Nome = teatro.nome;
                output.Localizacao = teatro.localizacao;
                output.Morada = teatro.morada;
                output.Telefone = teatro.telefone;
            }

            return Task.FromResult(output);
        }

        public override Task<Reply> InsertTeatro(Addteatro request, ServerCallContext context)
        {
            var teatro = new Teatro()
            {
                nome = request.Nome,
                localizacao = request.Localizacao,
                morada = request.Morada,
                telefone = request.Telefone,
            };

            _logger.LogInformation("Inserir Teatro.");

            try
            {
                _context.Teatrs.Add(teatro);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Teatro {request.Nome} foi inserido.",
                   IsOk = true
               }
            );
        }

        public override Task<Reply> UpdateTeatro(teatro request, ServerCallContext context)
        {
            var s = _context.Teatrs.Find(request.Id);

            if (s == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"O Teatro {request.Nome} com o ID {request.Id} não foi encontrado.",
                      IsOk = false
                  }
                );
            }

            s.nome = request.Nome;
            s.localizacao = request.Localizacao;
            s.morada = request.Morada;
            s.telefone = request.Telefone;

            _logger.LogInformation("Atualizar Teatro.");

            try
            {
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"O Teatro {request.Nome} com o ID {request.Id} foi atualizado.",
                   IsOk = true
               }
            );
        }

        public override Task<TeatroList> RetrieveAllTeatros(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos os Teatros: ");

            TeatroList list = new TeatroList();

            try
            {
                List<teatro> teatroList = new List<teatro>();

                var teatrs = _context.Teatrs.ToList();

                foreach (var c in teatrs)
                {
                    teatroList.Add(new teatro()
                    {
                        Id = c.id,
                        Nome = c.nome,
                        Localizacao = c.localizacao,
                        Morada = c.morada,
                        Telefone = c.telefone,
                    });
                }

                list.Items.AddRange(teatroList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }


        public override Task<sessao> GetSessaoInfo(SessaoLookupModel request, ServerCallContext context)
        {
            sessao output = new sessao();
            output.Espetaculos = new espetaculo();
            var sessao = _context.Sessas.Include(x => x.espetaculos).FirstOrDefault(x => x.id == request.SessaoId);
            _logger.LogInformation("A enviar resposta da Sessão...");

            if (sessao != null)
            {
                output.Id = sessao.id;
                output.Espetaculos.Id = sessao.espetaculos.id;
                output.Data = sessao.data;
                output.HoraInicio = sessao.horaInicio;
                output.HoraFim = sessao.horaFim;
                output.LugarTotal = sessao.lugarTotal;
                output.LugarDisponivel = sessao.lugarDisponivel;
            }

            return Task.FromResult(output);
        }

        public override Task<Reply> InsertSessao(Addsessao request, ServerCallContext context)
        {
            var sessao = new Sessao()
            {
                EspetaculoId = request.Espetaculos.Id,
                data = request.Data,
                horaInicio = request.HoraInicio,
                horaFim = request.HoraFim,
                lugarTotal = request.LugarTotal,
                lugarDisponivel = request.LugarDisponivel,
            };

            _logger.LogInformation("Inserir Sessão.");

            try
            {
                _context.Sessas.Add(sessao);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"A sessão {request.Espetaculos.Nome} foi inserido.",
                   IsOk = true
               }
            );
        }

        public override Task<Reply> UpdateSessao(sessao request, ServerCallContext context)
        {
            var s = _context.Sessas.Find(request.Id);

            if (s == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"A sessão {request.Espetaculos.Nome} com o ID {request.Id} não foi encontrado.",
                      IsOk = false
                  }
                );
            }

            //s.espetaculos = request.Espetaculos;
            s.data = request.Data;
            s.horaInicio = request.HoraInicio;
            s.horaFim = request.HoraFim;
            s.lugarTotal = request.LugarTotal;
            s.lugarDisponivel = request.LugarDisponivel;

            _logger.LogInformation("Atualizar Sessão.");

            try
            {
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"A sessão {request.Espetaculos.Nome} com o ID {request.Id} foi atualizado.",
                   IsOk = true
               }
            );
        }

        public override Task<SessaoList> RetrieveAllSessao(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos as Sessões: ");

            SessaoList list = new SessaoList();

            try
            {
                List<sessao> sessaoList = new List<sessao>();

                var sessas = _context.Sessas.Include(x => x.espetaculos).ToList();

                foreach (var c in sessas)
                {
                    var sess = new sessao();
                    sess.Espetaculos = new espetaculo();
                    sess.Id = c.id;
                    sess.Espetaculos.Id = c.espetaculos.id;
                    sess.Data = c.data;
                    sess.HoraInicio = c.horaInicio;
                    sess.HoraFim = c.horaFim;
                    sess.LugarTotal = c.lugarTotal;
                    sess.LugarDisponivel = c.lugarDisponivel;
                    sessaoList.Add(sess);
                }

                list.Items.AddRange(sessaoList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }

        public override Task<SessaoList> RetrieveFutureSessao(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos as Sessões futuras: ");

            SessaoList list = new SessaoList();

            try
            {
                List<sessao> sessaoList = new List<sessao>();

                var sessas = _context.Sessas.Include(x => x.espetaculos).ToList();

                foreach (var c in sessas)
                {
                    if (DateTime.ParseExact(c.data, "dd-MM-yyyy", CultureInfo.InvariantCulture).Date >= DateTime.Now.Date)
                    {
                        var sess = new sessao();
                        sess.Espetaculos = new espetaculo();
                        sess.Id = c.id;
                        sess.Espetaculos.Id = c.espetaculos.id;
                        sess.Data = c.data;
                        sess.HoraInicio = c.horaInicio;
                        sess.HoraFim = c.horaFim;
                        sess.LugarTotal = c.lugarTotal;
                        sess.LugarDisponivel = c.lugarDisponivel;
                        sessaoList.Add(sess);
                    }
                }

                list.Items.AddRange(sessaoList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }

        public override Task<Reply> DeleteSessao(SessaoLookupModel request, ServerCallContext context)
        {
            var s = _context.Sessas.Find(request.SessaoId);

            if (s == null)
            {
                return Task.FromResult(
                  new Reply()
                  {
                      Result = $"A sessão com o ID {request.SessaoId} não foi encontrada.",
                      IsOk = false
                  }
                );
            }

            _logger.LogInformation("Eliminar Sessão.");

            try
            {
                foreach (var c in _context.Bilhets)
                {
                    if (c.sessaoId == request.SessaoId)
                        _context.Bilhets.Remove(c);
                }
                _context.Sessas.Remove(s);
                var returnVal = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(
               new Reply()
               {
                   Result = $"A sessão com o ID {request.SessaoId} foi eliminada.",
                   IsOk = true
               }
            );
        }

        public override Task<recibo> ComprarBilhete(ComprarBilheteModel request, ServerCallContext context)
        {
            int quantidade = 0;
            foreach(var c in _context.Bilhets.Include(c => c.sessoes))
            {
                if (c.sessoes.id == request.SessaoId && c.ClienteId == null)
                    quantidade++;
            }
            if (quantidade < request.Quantidade)
                return Task.FromResult(new recibo { IsOk = false, Result = "Nao existe bilhetes suficientes!" });
            var sessa = _context.Sessas.Include(x => x.espetaculos).FirstOrDefault(x => x.id == request.SessaoId);
            if (_context.Clients.Find(request.Username).contaVirtual < sessa.espetaculos.preco * request.Quantidade)
                return Task.FromResult(new recibo { IsOk = false, Result = "Fundos insuficientess!" });
            quantidade = 0;
            var cliente = _context.Clients.Find(request.Username);
            var recibo = new Recibo();
            foreach (var c in _context.Bilhets)
            {
                if (c.sessoes.id == request.SessaoId && c.ClienteId == null && quantidade < request.Quantidade)
                {
                    c.ClienteId = cliente.username;
                    c.Cliente = cliente;
                    cliente.contaVirtual -= sessa.espetaculos.preco;
                    sessa.lugarDisponivel -= 1;
                    quantidade++;
                    c.Recibo = recibo;
                    recibo.ClienteId = cliente.username;
                    recibo.Cliente = cliente;
                    recibo.gasto += sessa.espetaculos.preco;
                    recibo.NumeroBilhetes++;
                }
            }
            _context.Recibos.Add(recibo);
            _context.SaveChanges();
            return Task.FromResult(new recibo { IsOk = true, Result = "Compra efectuada com sucesso!", ClienteId = request.Username,
            Dinheirogasto = recibo.gasto, Id = recibo.Id, NumBilhetes = recibo.NumeroBilhetes});
        }
        

        public override Task<bilhete> GetBilheteInfo(BilheteLookupModel request, ServerCallContext context)
        {
            bilhete output = new bilhete();
            output.Sessoes = new sessao();
            var bilhete = _context.Bilhets.Include(x=>x.sessoes).FirstOrDefault(x => x.id == request.BilheteId);
            _logger.LogInformation("A enviar resposta do Bilhete...");

            if (bilhete != null)
            {
                output.Id = bilhete.id;
                output.Sessoes.Id = bilhete.sessoes.id;
                output.Visto = bilhete.visto;
            }

            return Task.FromResult(output);
        }

        public override Task<BilheteList> GetBilheteUser(UserLookupModel request, ServerCallContext context)
        {
            var cliente = _context.Clients.Include(x => x.Bilhetes).FirstOrDefault(i => i.username == request.UserName);
            bilhete output;
            BilheteList list = new BilheteList();

            foreach (var c in cliente.Bilhetes)
            {
                output = new bilhete();
                output.Id = c.id;
                output.Visto = c.visto;
                list.Items.Add(output);
            }
            return Task.FromResult(list);
        }

        public override Task<BilheteList> RetrieveAllBilhetes(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos os Bilhetes: ");

            BilheteList list = new BilheteList();

            try
            {
                List<bilhete> bilheteList = new List<bilhete>();

                var bilhets = _context.Bilhets.Include(x => x.sessoes).ToList();

                foreach (var c in bilhets)
                {
                    bilhete bil = new bilhete();
                    bil.Sessoes = new sessao();
                    bil.Id = c.id;
                    bil.Sessoes.Id = c.sessoes.id;
                    bil.Visto = c.visto;
                    bilheteList.Add(bil);
                }

                list.Items.AddRange(bilheteList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }

        public override Task<BilheteList> RetrieveAllBilhetesBought(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Todos os Bilhetes: ");

            BilheteList list = new BilheteList();

            try
            {
                List<bilhete> bilheteList = new List<bilhete>();

                var bilhets = _context.Bilhets.Include(x => x.sessoes).ToList();

                foreach (var c in bilhets)
                {
                    if (c.ClienteId != null)
                    {
                        bilhete bil = new bilhete();
                        bil.Sessoes = new sessao();
                        bil.Id = c.id;
                        bil.Sessoes.Id = c.sessoes.id;
                        bil.Visto = c.visto;
                        bilheteList.Add(bil);
                    }
                }

                list.Items.AddRange(bilheteList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }

            return Task.FromResult(list);
        }

        public override Task<Reply> AnularBilhete(BilheteLookupModel request, ServerCallContext context)
        {
            var bilhete = _context.Bilhets.Include(c => c.Cliente).Include(c => c.sessoes).FirstOrDefault(c => c.id == request.BilheteId);
            var sessao = _context.Sessas.Include(x => x.espetaculos).First(x => x.id == bilhete.sessoes.id);
            var preco = _context.Espetaculs.Find(sessao.espetaculos.id).preco;
            bilhete.Cliente.contaVirtual += preco;
            sessao.lugarDisponivel += 1;
            bilhete.Cliente = null;
            bilhete.ClienteId = null;
            var recibo = _context.Recibos.Include(c => c.Bilhetes).FirstOrDefault(c => c.Id == bilhete.ReciboId);
            recibo.Bilhetes.Remove(bilhete);
            recibo.gasto -= preco;
            recibo.NumeroBilhetes--;
            if (recibo.NumeroBilhetes == 0)
                _context.Recibos.Remove(recibo);
            bilhete.ReciboId = null;
            bilhete.Recibo = null;
            _context.SaveChanges();
            return Task.FromResult(new Reply { IsOk = true, Result = "Bilhete eliminado com sucesso!" });
        }

        public override Task<NumBilhetes> QuantidadeBilhetes(SessaoLookupModel request, ServerCallContext context)
        {
            int quantidade = 0;
            foreach (var c in _context.Bilhets.Include(x => x.sessoes).Include(x => x.Cliente)) 
            {
                if (c.sessoes.id == request.SessaoId && c.ClienteId == null && c.Cliente == null)
                    quantidade++;
            }
            return Task.FromResult(new NumBilhetes { QuantidadeBilh = quantidade });
        }
        
        public override Task<Empty> VerBilhete(BilheteLookupModel request, ServerCallContext context)
        {
            var found = _context.Bilhets.Find(request.BilheteId);
            found.visto = true;
            _context.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Reply> AdicionarBilhetes(CriarBilhetes request, ServerCallContext context)
        {
            int total = 0;
            int maxBilhetes = 0;
            int ToUse;
            foreach(var c in _context.Bilhets)
            {
                if (c.sessaoId == request.SessaoId && c.ClienteId == null)
                    total++;
            }
            maxBilhetes = _context.Sessas.Find(request.SessaoId).lugarDisponivel;
            maxBilhetes -= total;
            if (maxBilhetes > request.Quantidade)
                ToUse = request.Quantidade;
            else
                ToUse = maxBilhetes;
            for(int i = 0; i < ToUse; i++)
            {
                Bilhete bil = new Bilhete();
                bil.ClienteId = null;
                bil.ReciboId = null;
                bil.sessaoId = request.SessaoId;
                bil.visto = false;
                _context.Bilhets.Add(bil);
            }
            _context.SaveChanges();
            return Task.FromResult(new Reply { IsOk = true, Result = $"Created {ToUse} bilhetes!" });
        }
    }
}
