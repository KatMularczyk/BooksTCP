#include "reciever.h"
#include "stdio.h"

#include <sys/socket.h>

void sendRequest(int sock, struct Filters filters)
{
    int buffIdx = 0;
    char buffer[MAX_FILTER_LEN * 3];

    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[buffIdx] = filters.title[i];
        buffIdx++;
        if (filters.title[i] == '\n') break;
    }
    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[buffIdx] = filters.author[i];
        buffIdx++;
        if (filters.author[i] == '\n') break;
    }
    for (int i = 0; i < MAX_FILTER_LEN; i++)
    {
        buffer[buffIdx] = filters.genre[i];
        buffIdx++;
        if (filters.genre[i] == '\n') break;
    }
    for (; buffIdx < MAX_FILTER_LEN * 3; buffIdx++)
    {
        buffer[buffIdx] = '\0';
    }
 
    send(sock, buffer, MAX_FILTER_LEN * 3, 0); // 786B
}

char getResponseWithSize(int sock, unsigned long* recievedSize)
{
    unsigned char pdest[4];

    size_t bytes_size = recv(sock, pdest, 8, 0);//8B

    unsigned long l = pdest[0] | (pdest[1] << 8) | 
                (pdest[2] << 16) | (pdest[3] << 24);
    *recievedSize = l;
    return l < 1;
}

char getResponseWithData(int sock, unsigned long size, char* buffer)
{
    size_t received = 0;
    while (received < size)
    {
        received += recv(sock, buffer + received, size - received, 0);
    }
    return received < size;
}