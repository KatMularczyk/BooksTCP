#include "reciever.h"

#include <sys/socket.h>

int sendRequest(struct Filters filters, int sock)
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
    
    return (int)send(sock, buffer, MAX_FILTER_LEN * 3, 0);
}

int getResponseWithSize(int sock)
{
    return 0;
}

int getResponseWithData(int sock)
{
    return 0;
}