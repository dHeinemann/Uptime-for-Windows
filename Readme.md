**Uptime for Windows** is a small Perl script to display the relative time since Windows was started. It works by parsing the 'Statistics since' date of `net statistics server` and calculating the time that has passed.

##Usage
    C:\Users\David>uptime
    Uptime: 15 hours, 6 minutes, 19 seconds.

##Requirements
* Microsoft Windows
* ActiveState or Strawberry Perl

##Installation
Copy both `Uptime.pl` and `uptime.bat` into a directory in your PATH (such as `C:\Windows`) to allow it to be run from anywhere in `Cmd.exe`.

##License
Uptime for Windows is published under the MIT License.

    Copyright (c) 2012 David Heinemann
    
    Permission is hereby granted, free of charge, to any person obtaining a
    copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:
    
    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
    OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
    CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
    TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
    SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
