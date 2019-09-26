# CMakeList.txt : CMake project for pcre, include source and define
# project specific logic here.
#
cmake_minimum_required (VERSION 3.8)

# The following variable describes the target OS we are building to.
set(CMAKE_SYSTEM_NAME WASI)
set(CMAKE_SYSTEM_VERSION 1)

set(CMAKE_CROSSCOMPILING TRUE)

# Advertise Emscripten as a 32-bit platform (as opposed to CMAKE_SYSTEM_PROCESSOR=x86_64 for 64-bit platform),
# since some projects (e.g. OpenCV) use this to detect bitness.
set(CMAKE_SYSTEM_PROCESSOR x86)

# Tell CMake how it should instruct the compiler to generate multiple versions of an outputted .so library: e.g. "libfoo.so, libfoo.so.1, libfoo.so.1.4" etc.
# This feature is activated if a shared library project has the property SOVERSION defined.
set(CMAKE_SHARED_LIBRARY_SONAME_C_FLAG "-Wl,-soname,")

# In CMake, CMAKE_HOST_WIN32 is set when we are cross-compiling from Win32 to Emscripten: http://www.cmake.org/cmake/help/v2.8.12/cmake.html#variable:CMAKE_HOST_WIN32
# The variable WIN32 is set only when the target arch that will run the code will be WIN32, so unset WIN32 when cross-compiling.
set(WIN32)

# The same logic as above applies for APPLE and CMAKE_HOST_APPLE, so unset APPLE.
set(APPLE)

# And for UNIX and CMAKE_HOST_UNIX. However, Emscripten is often able to mimic being a Linux/Unix system, in which case a lot of existing CMakeLists.txt files can be configured for Emscripten while assuming UNIX build, so this is left enabled.
set(UNIX 1)

set(CMAKE_C_FLAGS "-v -O2")
set(CMAKE_CXX_FLAGS "-v -O2")

add_definitions(-DPCRE2_CODE_UNIT_WIDTH=16)

# Add source to this project's executable.
include_directories("../core" "../vendor/libcxx" "../vendor/pcre/include")
file(GLOB source_files "*.cc")
add_library (bindings STATIC "${CMAKE_CURRENT_BINARY_DIR}/../core/core.lib" ${source_files})

# TODO: Add tests and install targets if needed.
