#include "Utils.h"


bool FindArrStr(Array arr, String str) {
	for (size_t i = 0; i < arr.size; i++) {
		if (!strcmp(((String*)arr.data)[i].data, str.data))
			return true;
	}
	return false;
}

bool FindArrInt(Array arr, size_t num) {
	for (size_t i = 0; i < arr.size; i++) {
		if (((size_t*)arr.data)[i] == num)
			return true;
	}
	return false;
}

void AddStrArray(Array* arr, String str) {
	for (int i = 0; i < arr->size; i++)
		if (FindArrStr(*arr, str))
			return;
	if (arr->size >= CITY_TEMA_MAX)
		ERRO();
	STRCOPY(((String*)arr->data)[arr->size], str.data);
	arr->size++;
}
