#include "range-wrapper.h"
#include "range.h"

void* RangeWrapper::construct_range() {
  Range* r = new Range();
  return r;
}

void RangeWrapper::release_instance(void* rInstance) {
  Range* r = (Range*)rInstance;
  delete r;
}

void* RangeWrapper::get_start(void* rInstance) {
  Range* r = (Range*)rInstance;
  return r.start;
}

void* RangeWrapper::get_end(void* rInstance) {
  Range* r = (Range*)rInstance;
  return r.end;
}