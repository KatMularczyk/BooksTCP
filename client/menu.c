#include "menu.h"

#include <stdio.h>
#include <string.h>

void getFilters(struct Filters *filters)
{
    printf("Filter by author, title or/and genre "
        "(you can leave filter blank or enter multiple separated "
        "by ',' up to %d characters)\n", MAX_FILTER_LEN);

    printf("Filter by AUTHOR: ");
    fgets(filters->author, MAX_FILTER_LEN, stdin);

    printf("Filter by TITLE: ");
    fgets(filters->title, MAX_FILTER_LEN, stdin);

    printf("Filter by GENRE: ");
    fgets(filters->genre, MAX_FILTER_LEN, stdin);

    processFilters(filters);
}

void processFilters(struct Filters *filters)
{
    size_t len = strlen(filters->author);
    if (len > 0 && filters->author[len - 1] == '\n')
    {
        filters->author[len - 1] = '\0';
    }
    len = strlen(filters->title);
    if (len > 0 && filters->title[len - 1] == '\n')
    {
        filters->title[len - 1] = '\0';
    }
    len = strlen(filters->genre);
    if (len > 0 && filters->genre[len - 1] == '\n')
    {
        filters->genre[len - 1] = '\0';
    }
}
