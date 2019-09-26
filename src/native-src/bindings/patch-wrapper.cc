#include "patch.h"
#include "patch-wrapper.h"
#include "optional.h"
#include "text.h"
#include <memory>
#include <sstream>
#include <vector>
#include "point-wrapper.h"
// #include "string-conversion.h"

using std::move;
using std::vector;
using std::u16string;
using Change = Patch::Change;

static const char *InvalidSpliceMessage = "Patch does not apply";

void* PatchWrapper::construct_patch() {
  Patch* p = new Patch();
  return p;
}

void PatchWrapper::release_instance(void* pInstance) {
  Patch* p = (Patch*)pInstance;
  delete p;
}

void PatchWrapper::splice(void* pInstance, void* start, void* deletion_extent, void* insertion_extent,
  std::basic_string<char16_t> deleted_text, std::basic_string<char16_t> inserted_text, unsigned deleted_text_size) {

  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;
  Point* deletion_extent_point = (Point*)deletion_extent;
  Point* insertion_extent_point = (Point*)insertion_extent;

  Text deleted_text_text = new Text(deleted_text);
  auto deleted_text_optional_text = optional(deleted_text_text);

  Text inserted_text_text = new Text(inserted_text);
  auto inserted_text_optional_text = optional(inserted_text_text);

  //if (info.Length() >= 4) {
  //  auto deleted_string = string_conversion::string_from_js(info[3]);
  //  if (!deleted_string) return;
  //  
  //}

  //if (info.Length() >= 5) {
  //  auto inserted_string = string_conversion::string_from_js(info[4]);
  //  if (!inserted_string) return;
  //  inserted_text = Text{move(*inserted_string)};
  //}

  if (!patch->splice(*start_point, *deletion_extent_point, *insertion_extent_point, move(deleted_text_optional_text), move(inserted_text_optional_text))) {
    throw InvalidSpliceMessage;
  }
}

void PatchWrapper::splice_old(void* pInstance, void* start, void* deletion_extent, void* insertion_extent) {
  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;
  Point* deletion_extent_point = (Point*)deletion_extent;
  Point* insertion_extent_point = (Point*)insertion_extent;
  patch->splice_old(*start, *deletion_extent_point, *insertion_extent_point);
}

void* PatchWrapper::copy(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  return &patch->copy();
}

void* PatchWrapper::invert(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  return &patch->invert();
}

vector<Change*> PatchWrapper::get_changes(void* pInstance) {
  Patch* patch = (Patch*)pInstance;

  vector<Change> changes = patch->get_changes();
  vector<Change*> changesResult{{}};

  for (auto change : changes) {
    changesResult.push_back(&change);
  }

  return changesResult;
}

vector<Change*> get_changes_in_old_range(void* pInstance, void* start, void* end) {
  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;
  Point* end_point = (Point*)end;

  vector<Change> changes = patch->grab_changes_in_old_range(*start_point, *end_point);
  vector<Change*> changesResult{{}};

  for (auto change : changes) {
    changesResult.push_back(&change);
  }

  return changesResult;
}

vector<Change*> get_changes_in_new_range(void* pInstance, void* start, void* end) {
  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;
  Point* end_point = (Point*)end;

  vector<Change> changes = patch->grab_changes_in_new_range(*start_point, *end_point);
  vector<Change*> changesResult{{}};

  for (auto change : changes) {
    changesResult.push_back(&change);
  }

  return changesResult;
}

void* PatchWrapper::change_for_old_position(void* pInstance, void* start) {
  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;

  auto change = patch->grab_change_starting_before_old_position(*start_point);
  if (change) {
    return *change;
  } else {
    return NULL;
  }
}

void* PatchWrapper::change_for_new_position(void* pInstance, void* start) {
  Patch* patch = (Patch*)pInstance;
  Point* start_point = (Point*)start;

  auto change = patch->grab_change_starting_before_new_position(*start_point);
  if (change) {
    return *change;
  } else {
    return NULL;
  }
}

std::string PatchWrapper::serialize(void* pInstance) {
  Patch* patch = (Patch*)pInstance;

  static vector<uint8_t> output;
  output.clear();
  Serializer serializer(output);
  patch->serialize(serializer);
  char* result = reinterpret_cast<char*>(output.data());

  return std::string(result);
}

void* PatchWrapper::deserialize(std::vector<uint8_t> data) {
  Deserializer deserializer(data);
  Patch* patch = &Patch{deserializer};
  return &patch;
}

void* PatchWrapper::compose(vector<Patch> patches) {
  Patch combination;
  bool left_to_right = true;

  for (uint32_t i = 0, n = patches.size(); i < n; i++) {
    Patch& patch = patches[i];

    if (!combination.combine(patch, left_to_right)) {
      throw InvalidSpliceMessage;
    }
    left_to_right = !left_to_right;
  }

  return &move(combination);
}

std::string PatchWrapper::get_dot_graph(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  std::string graph = patch->get_dot_graph();
  return graph;
}

std::string PatchWrapper::get_json(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  std::string graph = patch->get_json();
  return graph;
}

uint32_t PatchWrapper::get_change_count(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  uint32_t change_count = patch->get_change_count();
  return change_count;
}

void* PatchWrapper::get_bounds(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  auto bounds = patch->get_bounds();
  if (bounds) {
    return bounds;
  }
  return NULL;
}

void PatchWrapper::rebalance(void* pInstance) {
  Patch* patch = (Patch*)pInstance;
  patch->rebalance();
}
