#include <memory>
#include <vector>
#include "patch.h"

using std::runtime_error;
using std::string;
using std::vector;

bool splice(Patch &patch, Point start, Point deleted_extent, Point inserted_extent) {
  return patch.splice(
    start,
    deleted_extent,
    inserted_extent
  );
}

bool splice_with_text(Patch &patch, Point start, Point deleted_extent, Point inserted_extent,
                      const string &deleted_text, const string &inserted_text) {
  return patch.splice(
    start,
    deleted_extent,
    inserted_extent,
    Text(deleted_text.begin(), deleted_text.end()),
    Text(inserted_text.begin(), inserted_text.end())
  );
}

template <typename T>
void change_set_noop(Patch::Change &change, T const &) {}
