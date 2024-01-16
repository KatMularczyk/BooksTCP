#ifndef RECIEVER_H
#define RECIEVER_H

#include "menu.h"

char sendRequest(int sock, struct Filters filters);
char getResponseWithSize(int sock, unsigned long* recievedSize);
char getResponseWithData(int sock, unsigned long size, char* buffer);

#endif
