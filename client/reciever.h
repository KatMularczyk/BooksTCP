#ifndef RECIEVER_H
#define RECIEVER_H

#include "menu.h"

int sendRequest(int sock, struct Filters filters);
int getResponseWithSize(int sock, unsigned long* recievedSize);
int getResponseWithData(int sock, unsigned long size, char* buffer);

#endif
