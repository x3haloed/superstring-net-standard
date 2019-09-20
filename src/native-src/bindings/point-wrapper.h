#ifndef SUPERSTRING_POINT_WRAPPER_H
#define SUPERSTRING_POINT_WRAPPER_H

#include "point.h"

class PointWrapper {
public:
  static void* construct_point();
  static void release_instance(void* pInstance);
  static unsigned get_row(void* pInstance);
  static unsigned get_column(void* pInstance);
};

#endif // SUPERSTRING_POINT_WRAPPER_H
