#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <netdb.h>

int main(int argc, char **argv)
{
    struct sockaddr_in endpoint;
    int sdsocket;
    int addrlen = sizeof(struct sockaddr_in);

    if (argc != 3)
    {
        printf("Parameters required: [ip] [port]\nExiting...\n");
        return 1;
    }

    struct hostent *he = gethostbyname(argv[1]);
    if (he == NULL)
    {
        printf("Unknown host: %s\n",argv[1]);
        return 0;
    }

    endpoint.sin_family = AF_INET;
    endpoint.sin_port = htons(atoi(argv[2]));
    endpoint.sin_addr = *(struct in_addr*) he->h_addr;

    if ((sdsocket = socket(AF_INET, SOCK_STREAM, 0)) < 0)
    {
        printf("Failed to create socket!\n");
        return 1;
    }

    if (connect(sdsocket,(struct sockaddr*) &endpoint, addrlen) < 0)
    {
        printf("Connection to server failed!\n");
        return 0;
    }
    else
    {
        printf("Connection successfull!\n");
    }










    close(sdsocket);
    printf("Connection closed!\n");
    return 0;
}