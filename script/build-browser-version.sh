#!/usr/bin/env bash

# source emsdk-portable/emsdk_env.sh

mkdir -p build

(cd build && exec clang -S -emit-llvm -O2       \
  -I ../vendor/pcre/10.23/src                   \
  -I ../vendor/pcre/include                     \
  -D HAVE_CONFIG_H                              \
  -D PCRE2_CODE_UNIT_WIDTH=16                   \
  ../vendor/pcre/pcre2_chartables.c             \
  ../vendor/pcre/10.23/src/pcre2_auto_possess.c \
  ../vendor/pcre/10.23/src/pcre2_compile.c      \
  ../vendor/pcre/10.23/src/pcre2_config.c       \
  ../vendor/pcre/10.23/src/pcre2_context.c      \
  ../vendor/pcre/10.23/src/pcre2_dfa_match.c    \
  ../vendor/pcre/10.23/src/pcre2_error.c        \
  ../vendor/pcre/10.23/src/pcre2_find_bracket.c \
  ../vendor/pcre/10.23/src/pcre2_jit_compile.c  \
  ../vendor/pcre/10.23/src/pcre2_maketables.c   \
  ../vendor/pcre/10.23/src/pcre2_match.c        \
  ../vendor/pcre/10.23/src/pcre2_match_data.c   \
  ../vendor/pcre/10.23/src/pcre2_newline.c      \
  ../vendor/pcre/10.23/src/pcre2_ord2utf.c      \
  ../vendor/pcre/10.23/src/pcre2_pattern_info.c \
  ../vendor/pcre/10.23/src/pcre2_serialize.c    \
  ../vendor/pcre/10.23/src/pcre2_string_utils.c \
  ../vendor/pcre/10.23/src/pcre2_study.c        \
  ../vendor/pcre/10.23/src/pcre2_substitute.c   \
  ../vendor/pcre/10.23/src/pcre2_substring.c    \
  ../vendor/pcre/10.23/src/pcre2_tables.c       \
  ../vendor/pcre/10.23/src/pcre2_ucd.c          \
  ../vendor/pcre/10.23/src/pcre2_valid_utf.c    \
  ../vendor/pcre/10.23/src/pcre2_xclass.c       \
)

(cd build && exec clang -S -emit-llvm -O2           \
  -std=c++11                                        \
  -I ../src/native-src/core                            \
  -I ../vendor/libcxx                                  \
  -I ../vendor/pcre/include                            \
  -D PCRE2_CODE_UNIT_WIDTH=16                       \
  -xc++                                             \
  ../src/native-src/core/*.cc                          \
)

(cd build && exec clang -S -emit-llvm -O2           \
  -I ../src/native-src/core                            \
  -I ../vendor/libcxx                                  \
  -I ../vendor/pcre/include                            \
  ./*.ll                                      \
  ../src/native-src/bindings/point-wrapper.cc                          \
  ../src/native-src/bindings/change-wrapper.cc                          \
  ../src/native-src/bindings/patch-wrapper.cc                          \
  ../src/native-src/bindings/range-wrapper.cc                          \
)

clang                                               \
  -target wasm32-wasi                               \
  --sysroot /opt/wasi-sdk/share/wasi-sysroot     \
  -nostartfiles                                     \
  --for-linker=--no-entry                           \
  --for-linker=--export=_ZN12PointWrapper15construct_pointEv           \
  --for-linker=--export=_ZN12PointWrapper16release_instanceEPv           \
  --for-linker=--export=_ZN12PointWrapper7get_rowEPv           \
  --for-linker=--export=_ZN12PointWrapper10get_columnEPv           \
  --for-linker=--demangle                           \
  -s                                                \
  -o superstring.wasm                               \
  -O2                                               \
  -D PCRE2_CODE_UNIT_WIDTH=16                       \
  build/*.ll                                      \
  "$@"

# rm -f build/pcre.ll
# llvm-link -S -v -o build/pcre.ll build/*.ll

# llc pcre.ll

# clang                                               \
#   -target wasm32-wasi                               \
#   --sysroot /home/ckirby/code/wasi-libc/sysroot     \
#   -std=c++11                                        \
#   -nostartfiles                                     \
#   --for-linker=--no-entry                           \
#   -s                                                \
#   -o superstring.wasm                               \
#   -O2                                               \
#   -I src/native-src/bindings/em                     \
#   -I src/native-src/core                            \
#   -I vendor/libcxx                                  \
#   -I vendor/pcre/include                            \
#   -D PCRE2_CODE_UNIT_WIDTH=16                       \
#   -xc++                                             \
#   src/native-src/core/*.cc                          \
#   src/native-src/bindings/em/*.cc                   \
#   build/pcre.s                                      \
#   "$@"