#include "auto-wrap.h"
#include "text-buffer.h"
#include "marker-index.h"
#include <vector>

using std::string;
using std::u16string;

static TextBuffer *construct(const std::wstring &text) {
  return new TextBuffer(u16string(text.begin(), text.end()));
}

// static optional<Range> find_sync(TextBuffer &buffer, std::wstring js_pattern, bool ignore_case, bool unicode, Range range) {
//   u16string pattern(js_pattern.begin(), js_pattern.end());
//   u16string error_message;
//   Regex regex(pattern, &error_message, ignore_case, unicode);
//   if (!error_message.empty()) {
//     return emscripten::val(string(error_message.begin(), error_message.end()));
//   }

//   auto result = buffer.find(regex, range);
//   if (result) {
//     return emscripten::val(*result);
//   }

//   return emscripten::val::null();
// }

// static vector(Range) find_all_sync(TextBuffer &buffer, std::wstring js_pattern, bool ignore_case, bool unicode, Range range) {
//   u16string pattern(js_pattern.begin(), js_pattern.end());
//   u16string error_message;
//   Regex regex(pattern, &error_message, ignore_case, unicode);
//   if (!error_message.empty()) {
//     return emscripten::val(string(error_message.begin(), error_message.end()));
//   }

//   return em_transmit(buffer.find_all(regex, range));
// }

// static emscripten::val find_and_mark_all_sync(TextBuffer &buffer, MarkerIndex &index, unsigned next_id,
//                                               bool exclusive, std::wstring js_pattern, bool ignore_case, bool unicode,
//                                               Range range) {
//   u16string pattern(js_pattern.begin(), js_pattern.end());
//   u16string error_message;
//   Regex regex(pattern, &error_message, ignore_case, unicode);
//   if (!error_message.empty()) {
//     return emscripten::val(string(error_message.begin(), error_message.end()));
//   }

//   return emscripten::val(buffer.find_and_mark_all(index, next_id, exclusive, regex, range));
// }

// static emscripten::val line_ending_for_row(TextBuffer &buffer, uint32_t row) {
//   auto line_ending = buffer.line_ending_for_row(row);
//   if (line_ending) {
//     string result;
//     for (const uint16_t *character = line_ending; *character != 0; character++) {
//       result += (char)*character;
//     }
//     return emscripten::val(result);
//   }
//   return emscripten::val::undefined();
// }

static uint32_t character_index_for_position(TextBuffer &buffer, Point position) {
  return buffer.clip_position(position).offset;
}

static uint32_t get_line_count(TextBuffer &buffer) {
  return buffer.extent().row + 1;
}

static Point position_for_character_index(TextBuffer &buffer, long index) {
  return index < 0 ?
    Point{0, 0} :
    buffer.position_for_offset(static_cast<uint32_t>(index));
}