#include "point-wrapper.h"
#include "point.h"

void* PointWrapper::construct_point()
{
    Point* p = new Point();
    return p;
}

void PointWrapper::release_instance(void* pInstance)
{
    Point* p = (Point*)pInstance;
    delete p;
}

unsigned PointWrapper::get_row(void* pInstance) {
  Point* p = (Point*)pInstance;
  return p.row;
}

unsigned PointWrapper::get_column(void* pInstance) {
  Point* p = (Point*)pInstance;
  return p.column;
}
