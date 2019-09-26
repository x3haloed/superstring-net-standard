#include "change-wrapper.h"
#include "patch.h"

using Change = Patch::Change;

void* ChangeWrapper::construct_change() {
    Change* c = new Change();
    return c;
}

void ChangeWrapper::release_instance(void* cInstance) {
    Change* c = (Change*)cInstance;
    delete c;
}

void* ChangeWrapper::get_old_start(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.old_start;
}

void* ChangeWrapper::get_new_start(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.new_start;
}

void* ChangeWrapper::get_old_end(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.old_end;
}

void* ChangeWrapper::get_new_end(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.new_end;
}

uint32_t ChangeWrapper::get_preceding_old_text_length(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.preceding_old_text_size;
}

uint32_t ChangeWrapper::get_preceding_new_text_length(void* cInstance) {
  Change* c = (Change*)cInstance;
  return change.preceding_new_text_size;
}

std::string ChangeWrapper::to_string(void* cInstance) {
  Change* c = (Change*)cInstance;
  std::stringstream result;
  result << change;
  return result.str();
}
