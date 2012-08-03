#!C:\strawberry\perl\bin\perl.exe
use warnings;
use strict;
use DateTime;

# Copyright (c) 2012 David Heinemann
# 
# Permission is hereby granted, free of charge, to any person obtaining
# a copy of this software and associated documentation files (the
# "Software"), to deal in the Software without restriction, including
# without limitation the rights to use, copy, modify, merge, publish,
# distribute, sublicense, and/or sell copies of the Software, and to
# permit persons to whom the Software is furnished to do so, subject to
# the following conditions:
#
# The above copyright notice and this permission notice shall be
# included in all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
# EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
# MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
# IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
# CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
# TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
# SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

my @stats = split("\n", `net statistics server`);
my ($bootDay, $bootMonth, $bootYear);
if ($stats[3] =~ /\d{1,2}\/\d{1,2}\/\d{4}/p)
{
    ($bootDay, $bootMonth, $bootYear) = split('/', ${^MATCH});
}

my ($bootHour, $bootMinute, $bootSecond);
if ($stats[3] =~ /\d{1,2}:\d{2}:\d{2}/p)
{
    ($bootHour, $bootMinute, $bootSecond) = split(':', ${^MATCH});

    if ($stats[3] =~ /PM/p)
    {
        $bootHour += 12;
    }
}

my $bootTime = DateTime->new(
    year   => $bootYear,
    month  => $bootMonth,
    day    => $bootDay,
    hour   => $bootHour,
    minute => $bootMinute,
    second => $bootSecond
);

my $currentTime = DateTime->now;
my $timeDifference = $currentTime->subtract_datetime($bootTime);

my $outputString = "Uptime:";

$outputString .= ' ' . $timeDifference->years   . ' years,'   if ($timeDifference->years > 0);
$outputString .= ' ' . $timeDifference->months  . ' months,'  if ($timeDifference->months > 0);
$outputString .= ' ' . $timeDifference->weeks   . ' weeks,'   if ($timeDifference->weeks > 0);
$outputString .= ' ' . $timeDifference->days    . ' days,'    if ($timeDifference->days > 0);
$outputString .= ' ' . $timeDifference->hours   . ' hours,'   if ($timeDifference->hours > 0);
$outputString .= ' ' . $timeDifference->minutes . ' minutes,' if ($timeDifference->minutes > 0);
$outputString .= ' ' . $timeDifference->seconds . ' seconds.';

print("$outputString\n");
