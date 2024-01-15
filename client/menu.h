#ifndef MENU_H
#define MENU_H

#define MAX_FILTER_LEN 256 // 256*3 = 786

struct Filters
{
    char author[MAX_FILTER_LEN];
    char title[MAX_FILTER_LEN];
    char genre[MAX_FILTER_LEN];
};

void getFilters(struct Filters *filters);
void processFilters(struct Filters *filters);

#endif
