#include "reciever.h"

#include <sys/socket.h>

int sendRequest(int sock, struct Filters filters)
{
    int bIdx = -1;
    char buffer[MAX_FILTER_LEN * 3];

    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[++bIdx] = filters.author[i];
        if (filters.author[i] == '\n') break;
    }
    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[++bIdx] = filters.title[i];
        if (filters.author[i] == '\n') break;
    }
    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[++bIdx] = filters.genre[i];
        if (filters.author[i] == '\n') break;
    }
    for (; bIdx < MAX_FILTER_LEN * 3; ++bIdx)
    {
        buffer[bIdx] = '\0';
    }
    
    return (int)send(sock, buffer, MAX_FILTER_LEN * 3, 0); // 786B
}

int getResponseWithSize(int sock, unsigned long* recievedSize)
{
    return recv(sock, recievedSize, sizeof(unsigned long), 0); //8B
}

int getResponseWithData(int sock, unsigned long size, char* buffer)
{
    return 0;
}