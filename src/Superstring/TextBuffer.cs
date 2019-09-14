using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Superstring
{
    public class TextBuffer
    {
        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern void PrintHelloWorld();
               
        public TextBuffer text_buffer {get;set;}
        public std::unordered_set<CancellableWorker *> outstanding_workers {get;set;}
        private static void construct(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_length(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_extent(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_line_count(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void has_astral(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_text(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_character_at_position(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_text_in_range(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void set_text(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void set_text_in_range(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void line_for_row(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void line_length_for_row(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void line_ending_for_row(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_lines(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void character_index_for_position(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void position_for_character_index(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find_sync(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find_all(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find_all_sync(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find_and_mark_all_sync(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void find_words_with_subsequence_in_range(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void is_modified(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void load(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void base_text_matches_file(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void save(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void load_sync(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void save_sync(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void serialize_changes(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void deserialize_changes(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void reset(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void base_text_digest(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void get_snapshot(const Nan::FunctionCallbackInfo<v8::Value> &info);
        private static void dot_graph(const Nan::FunctionCallbackInfo<v8::Value> &info);

        private void cancel_queued_workers();




        public object[] findSync (pattern, range)
        {
            return this.findInRangeSync(pattern, DEFAULT_RANGE)
        }

        public object[] findAllInRangeSync (pattern, range)
        {
            var ignoreCase = false;
            var unicode = false;

            if (pattern.source)
            {
                ignoreCase = pattern.flags.includes('i');
                unicode = pattern.unicode;
                pattern = pattern.source;
            }

            const result = findAllSync.call(this, pattern, ignoreCase, unicode, range)
          if (typeof result === 'string')
            {
                throw new Error(result);
            }
            else
            {
                return result
          }
        }
        public findAllSync = function(pattern, range)
        {
            return this.findAllInRangeSync(pattern, DEFAULT_RANGE)
        }

        public findAndMarkAllInRangeSync = function(markerIndex, nextId, exclusive, pattern, range)
        {
            let ignoreCase = false
          let unicode = false
          if (pattern.source)
            {
                ignoreCase = pattern.flags.includes('i')
      unicode = pattern.unicode
      pattern = pattern.source
    }
            const result = findAndMarkAllSync.call(this, markerIndex, nextId, exclusive, pattern, ignoreCase, unicode, range)
          if (typeof result === 'string')
            {
                throw new Error(result);
            }
            else
            {
                return result
          }
        }

        public findAndMarkAllSync = function(markerIndex, nextId, exclusive, pattern)
        {
            return this.findAndMarkAllInRangeSync(markerIndex, nextId, exclusive, pattern, DEFAULT_RANGE)
        }

        TextBuffer.prototype.find = function(pattern)
        {
            return new Promise(resolve => resolve(this.findSync(pattern)))
        }

        TextBuffer.prototype.findInRange = function(pattern, range)
        {
            return new Promise(resolve => resolve(this.findInRangeSync(pattern, range)))
        }

        TextBuffer.prototype.findAll = function(pattern)
        {
            return new Promise(resolve => resolve(this.findAllSync(pattern)))
        }

        TextBuffer.prototype.findAllInRange = function(pattern, range)
        {
            return new Promise(resolve => resolve(this.findAllInRangeSync(pattern, range)))
        }

        TextBuffer.prototype.findWordsWithSubsequence = function(query, extraWordCharacters, maxCount)
        {
            const range = { start: { row: 0, column: 0}, end: this.getExtent()}
    return Promise.resolve(
      findWordsWithSubsequenceInRange.call(this, query, extraWordCharacters, range).slice(0, maxCount)
    )
  }

    TextBuffer.prototype.findWordsWithSubsequenceInRange = function(query, extraWordCharacters, maxCount, range)
    {
        return Promise.resolve(
          findWordsWithSubsequenceInRange.call(this, query, extraWordCharacters, range).slice(0, maxCount)
        )
    }

    TextBuffer.prototype.getCharacterAtPosition = function(position)
    {
        return String.fromCharCode(getCharacterAtPosition.call(this, position))
    }

    const {compose
} = Patch
  const {splice} = Patch.prototype

  Patch.compose = function (patches) {
    const result = compose.call(this, patches)
    if (!result) throw new Error('Patch does not apply')
    return result
  }

Patch.prototype.splice = Object.assign(function () {
    if (!splice.apply(this, arguments)) {
    throw new Error('Patch does not apply')
    }
}, splice)
} else {
  try {
    binding = require('./build/Release/superstring.node')
  } catch (e1) {
    try {
      binding = require('./build/Debug/superstring.node')
    } catch (e2) {
      throw e1
    }
  }

  const {TextBuffer, TextWriter, TextReader} = binding
  const {
    load, save, baseTextMatchesFile,
    find, findAll, findSync, findAllSync, findWordsWithSubsequenceInRange
  } = TextBuffer.prototype

  TextBuffer.prototype.load = function (source, options, progressCallback) {
    if (typeof options !== 'object')
    {
        progressCallback = options
      options = { }
    }

    const computePatch = options.patch === false ? false : true
    const discardChanges = options.force === true ? true : false
    const encoding = normalizeEncoding(options.encoding || 'UTF-8')

    return new Promise((resolve, reject) => {
        const completionCallback = (error, result) => {
        error? reject(error) : resolve(result)
      }

      if (typeof source === 'string')
    {
        const filePath = source
        load.call(
          this,
          completionCallback,
          progressCallback,
          discardChanges,
          computePatch,
          filePath,
          encoding
        )
      }
    else
    {
        const stream = source
        const writer = new TextWriter(encoding)
        stream.on('data', (data) => writer.write(data))
        stream.on('error', reject)
        stream.on('end', () => {
            writer.end()
          load.call(
            this,
            completionCallback,
            progressCallback,
            discardChanges,
            computePatch,
            writer
          )
        })
      }
})
  }

  TextBuffer.prototype.save = function(destination, encoding = 'UTF8')
{
    const CHUNK_SIZE = 10 * 1024

    encoding = normalizeEncoding(encoding)

    return new Promise((resolve, reject) => {
        if (typeof destination === 'string')
        {
            const filePath = destination
          save.call(this, filePath, encoding, (error) => {
            error? reject(error) : resolve()
        })
        }
        else
        {
            const stream = destination
        const reader = new TextReader(this, encoding)
        const buffer = Buffer.allocUnsafe(CHUNK_SIZE)
        writeToStream(null)

        stream.on('error', (error) => {
            reader.destroy()
          reject(error)
        })

        function writeToStream()
            {
                const bytesRead = reader.read(buffer)
          if (bytesRead > 0)
                {
                    stream.write(buffer.slice(0, bytesRead), (error) => {
                        if (!error) writeToStream()
                    })
          }
                else
                {
                    stream.end(() => {
                        reader.end()
                      resolve()
                    })
              }
            }
        }
    })
  }

TextBuffer.prototype.find = function(pattern)
{
    return this.findInRange(pattern, null)
  }

TextBuffer.prototype.findInRange = function(pattern, range)
{
    return new Promise((resolve, reject) => {
        find.call(this, pattern, (error, result) => {
            error? reject(error) : resolve(result.length > 0 ? interpretRange(result) : null)
        }, range)
    })
  }

TextBuffer.prototype.findAll = function(pattern)
{
    return this.findAllInRange(pattern, null)
  }

TextBuffer.prototype.findAllInRange = function(pattern, range)
{
    return new Promise((resolve, reject) => {
        findAll.call(this, pattern, (error, result) => {
            error? reject(error) : resolve(interpretRangeArray(result))
        }, range)
    })
  }

public object findSync(pattern)
{
    return this.findInRangeSync(pattern, null)
}

public object[] findInRangeSync (pattern, range)
{
    const result = findSync.call(this, pattern, range)
    return result.length > 0 ? interpretRange(result) : null;
}

public object findAllSync (pattern)
{
    return interpretRangeArray(findAllSync.call(this, pattern, null));
}

TextBuffer.prototype.findAllInRangeSync = function(pattern, range)
{
    return interpretRangeArray(findAllSync.call(this, pattern, range))
  }

TextBuffer.prototype.findWordsWithSubsequence = function(query, extraWordCharacters, maxCount)
{
    return this.findWordsWithSubsequenceInRange(query, extraWordCharacters, maxCount, {
    start: { row: 0, column: 0},
      end: this.getExtent()
    })
  }

TextBuffer.prototype.findWordsWithSubsequenceInRange = function(query, extraWordCharacters, maxCount, range)
{
    return new Promise(resolve =>
      findWordsWithSubsequenceInRange.call(this, query, extraWordCharacters, maxCount, range, (matches, positions) => {
          if (!matches)
          {
              resolve(null)
            return
          }

          let positionArrayIndex = 0
        for (let i = 0, n = matches.length; i < n; i++)
          {
              let positionCount = positions[positionArrayIndex++]
          matches[i].positions = interpretPointArray(positions, positionArrayIndex, positionCount)
          positionArrayIndex += 2 * positionCount
        }
          resolve(matches)
      })
    )
  }

TextBuffer.prototype.baseTextMatchesFile = function(source, encoding = 'UTF8')
{
    return new Promise((resolve, reject) => {
        const callback = (error, result) => {
            if (error)
            {
                reject(error)
            }
            else
            {
                resolve(result)
          }
        }

      if (typeof source === 'string')
        {
            baseTextMatchesFile.call(this, callback, source, encoding)
      }
        else
        {
            const stream = source
        const writer = new TextWriter(encoding)
        stream.on('data', (data) => writer.write(data))
        stream.on('error', reject)
        stream.on('end', () => {
            writer.end()
          baseTextMatchesFile.call(this, callback, writer)
        })
      }
    })
  }

function interpretPointArray(rawData, startIndex, pointCount)
{
    const points = []
    for (let i = 0; i < pointCount; i++)
    {
        points.push({ row: rawData[startIndex++], column: rawData[startIndex++]})
    }
    return points
  }

private object[] interpretRangeArray(object[] rawData)
{
    var rangeCount = rawData.Length / 4;
    var ranges = new object[rangeCount];
    var rawIndex = 0;
    for (var rangeIndex = 0; rangeIndex < rangeCount; rangeIndex++)
    {
        ranges[rangeIndex] = interpretRange(rawData, rawIndex);
        rawIndex += 4;
    }
    return ranges;
}

private object interpretRange(object[] rawData, long index = 0)
{
    return new {
        start =
        new {
            row = rawData[index],
            column = rawData[index + 1],
        },
        end =
        new {
            row = rawData[index + 2],
            column = rawData[index + 3]
        }
    };
}

public static string normalizeEncoding(string encoding)
{
    encoding = encoding.ToUpperInvariant();
    encoding = Regex.Replace(encoding, @"/[^A - Z\d] / g", "");
    encoding = Regex.Replace(encoding, @"/ ^(UTF | UCS | ISO | WINDOWS | KOI8 | EUC)(\w) /", "$1-$2");
    encoding = Regex.Replace(encoding, @"/ ^(ISO - 8859)(\d) /", "$1-$2");
    encoding = Regex.Replace(encoding, @"/ ^(SHIFT)(\w) /", "$1-$2");

    return encoding;
}
}
}