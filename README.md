Pseudolocalizer
===============
The Pseudolocalizer is a tool for testing internationalization aspects of software. Specifically, it reads string values from resource files in the Resx format and generates fake translations for the "qps-ploc" pseudo-locale.

The tool is run from the command line and provides the following options for the fake translation:

- Add accents on all letters so that non-localized text can be spotted -- but without making the text unreadable.
- Make all words 30% longer, to ensure that there is room for translations.
- Add brackets to show the start and end of each localized string.
  This makes it possible to spot strings that have been cut off.
- Reverse all words ("mirror"), to simulate right-to-left locales.
- Replace all characters with underscores so that non-localized text can be spotted.

See also
--------
- [WPF Localization Guidance Whitepaper by Rick Strahl and Michele Leroux Bustamante](http://wpflocalization.codeplex.com/releases/view/29389)
- [Stack Overflow: How to use enable pseudo-locale in Windows for testing?](http://stackoverflow.com/questions/7042920/how-to-use-enable-pseudo-locale-in-windows-for-testing/)

License (3-clause BSD)
----------------------
Copyright (c) 2012, Anders Kaplan.
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
* Neither the name of the <organization> nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
