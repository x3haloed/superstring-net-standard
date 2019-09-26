#include "patch.h"
#include <vector>

using Change = Patch::Change;

class PatchWrapper {
 public:
  static void* construct_patch();
  static void release_instance(void* pInstance);

  static void splice(
    void* pInstance,
	void* new_splice_start, void* new_deletion_extent, void* new_insertion_extent,
	  std::basic_string<char16_t> deleted_text, std::basic_string<char16_t> inserted_text, unsigned deleted_text_size);
  static void splice_old(void* pInstance, void* start, void* deletion_extent, void* insertion_extent);
  static void* copy(void* pInstance);
  static void* invert(void* pInstance);
  static std::vector<Change*> get_changes(void* pInstance);
  static std::vector<Change*> get_changes_in_old_range(void* pInstance, void* start, void* end);
  static std::vector<Change*> get_changes_in_new_range(void* pInstance, void* start, void* end);
  static void* change_for_old_position(void* pInstance, void* start);
  static void* change_for_new_position(void* pInstance, void* start);
  static std::string serialize(void* pInstance);
  static void* deserialize(std::vector<uint8_t> data);
  static void* compose(std::vector<Patch*> patches);
  static std::string get_dot_graph(void* pInstance);
  static std::string get_json(void* pInstance);
  static uint32_t get_change_count(void* pInstance);
  static void* get_bounds(void* pInstance);
  static void rebalance(void* pInstance);
};
