#include "reciever.h"
#include "stdio.h"

#include <sys/socket.h>

char sendRequest(int sock, struct Filters filters)
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
    
    size_t bytes_size = send(sock, buffer, MAX_FILTER_LEN * 3, 0); // 786B
    printf("sendRequest=%u\n", bytes_size);
    return 0;
}

char getResponseWithSize(int sock, unsigned long* recievedSize)
{
    size_t bytes_size = recv(sock, recievedSize, sizeof(unsigned long), 0);//8B
    printf("getResponseWithSize=%u\n", bytes_size);
    return 0;
}

char getResponseWithData(int sock, unsigned long size, char* buffer)
{
    size_t received = 0;
    while (received < size)
    {
        received += recv(sock, buffer + received, (size_t)size - received, 0);
    }
    printf("getResponseWithData=%u\n", received);
    return 0;
}