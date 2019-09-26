#include "patch.h"

using Change = Patch::Change;

class ChangeWrapper {
public:
  static void* construct_change();
  static void release_instance(void* cInstance);
  static void* get_old_start(void* cInstance);
  static void* get_new_start(void* cInstance);
  static void* get_old_end(void* cInstance);
  static void* get_new_end(void* cInstance);
  static uint32_t get_preceding_old_text_length(void* cInstance);
  static uint32_t get_preceding_new_text_length(void* cInstance);
  static std::string to_string(void* cInstance);
};
