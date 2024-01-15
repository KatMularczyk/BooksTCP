#ifndef RECIEVER_H
#define RECIEVER_H

#include "menu.h"

int sendRequest(struct Filters filters, int sock);
int getResponseWithSize(int sock);
int getResponseWithData(int sock);




#endif
