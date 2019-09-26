#ifndef SUPERSTRING_RANGE_WRAPPER_H
#define SUPERSTRING_RANGE_WRAPPER_H

//#include "point.h"
//#include "range.h"

class RangeWrapper {
public:
  static void* construct_range();
  static void release_instance(void* rInstance);
  static void* get_start(void* rInstance);
  static void* get_end(void* rInstance);
};

#endif // SUPERSTRING_RANGE_WRAPPER_H
