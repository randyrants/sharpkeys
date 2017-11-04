## Project Description
SharpKeys is a utility that manages a Registry key that allows Windows to remap one key to any other key. Included in the application is a list of common keyboard keys and a Type Key feature to automatically recognize most keyboard keys. It was originally developed in C# using .NET v2 but has been updated to support .NET 4.0 Client Profile

## Original Mission:
This is something that I've thrown together to help people out with their keyboard mappings. What's a keyboard mapping? How many times a day do you accidentally hit cAPS lOCK BY MISTAKE AND END UP HAVING TO GO BAck and retype stuff? For me it was at least once an hour - in fact, I used to pop off the Caps Lock key so I wouldn't hit it anymore, but I found something better in Windows XP, as well as 2000, Server 2003, Vista, and Windows 7. There's a little used registry hack that allows you to remap keys across a keyboard. For me, this meant that I told my computer to treat Caps Lock as if it was a shift key, which it now does. 

The more I started working with other keyboard, the more I wanted to have this ability to map other keys across my keyboard, but working with the Hex numbers and having too look up scan codes could be painful... hence SharpKeys. 

SharpKeys is not responsible for any of the keyboard remapping functionality - it simply exposes a Registry key that controls how Windows remaps keys and has been available to us since Windows 2000.  The list of keys that are included in the application are from most of the US-based keyboards that I've used over the years and is not guaranteed to be 100% complete for world keyboards.

## Where can I get the compiled version?
Click the Releases button in the header above or go to https://github.com/randyrants/sharpkeys/releases directly

## How do I use it?  Getting Started
* Launch SharpKeys, by selecting it's icon from the Start menu. If there are any errors reported, please check the Troubleshooting section below 
* Add a new key mapping or edit an existing one 
* Click "Write to registry" and wait for a confirmation that the registry was successfully updated 
* Close SharpKeys and either log out (and back in) or reboot to enforce the new mappings 

## Things that SharpKeys _will_ do:
* Map an entire key to any other key - e.g. you could remap Caps Lock to a Shift key
* Remap more than one key to one single key - e.g. you could remap every key on a keyboard to the letter Q
* Force you to look for the Left or Right ALT key in the list of available keys because Type Key cannot scan for ALT

## Things that SharpKeys **_will not_** do:
* Allow you to swap two keys with each other - e.g. you can’t have Q and Z swap places because the remapping code would get confused
* Map multiple key presses to one key - e.g. it will not support an attempt to remap Ctrl+C to the F5 key
* Map mouse clicks to any key
* Support certain hardware keys that never make it to Windows - e.g. Logitech’s volume buttons or most Fn keys
* Support multiple mappings for different users - the Windows key being tweaked is for an entire machine
* Protect you from yourself - if you disable your DEL key and can’t login because Ctrl+Alt+Del doesn’t work now, you’ll have to reformat

## Hope for GitHub contributions:
* A more complete list to support more international keyboards
* An import/export functionality that allows people to swap keymappings easier
* Continued support for new .NET Frameworks
