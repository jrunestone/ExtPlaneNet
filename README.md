# ExtPlaneNet
A C# (Mono) library that uses the [ExtPlane plugin](https://github.com/vranki/ExtPlane) to ease communication with X-Plane on all platforms. Inspired by the [ExtPlaneInterface library for Java](https://github.com/pau662/ExtPlaneInterface) by pau662.

## License
**GNU GPLv3**

Copyright (C) 2015  Johan Johansson.

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

## Build
The project is built with .NET 4.5 and Mono in the Xamarin Studio IDE but should be compatible with Visual Studio. A prebuilt release DLL can be found in the `build` folder.

## How to use
### Prerequisites
You need X-Plane (demo works fine) with the [ExtPlane plugin](https://github.com/vranki/ExtPlane) installed. The library is built against .NET 4.5 (Mono).

### Connecting to X-Plane
Make sure X-Plane is started and the plugin is installed and active.

```
var iface = new ExtPlaneNet.ExtPlaneInterface();
iface.Connect();
```

This connects to the ExtPlane plugin with the default parameters (can be changed in the constructor). The connection process is synchronous.

### Subscribing to datarefs
When connected, you must subscribe to datarefs to be able to read or write them. Full list of datarefs: http://www.xsquawkbox.net/xpsdk/docs/DataRefs.txt. Subscribing to datarefs is done asynchronously.

```
// subscribe to a dataref (engine throttle lever positions)
iface.Subscribe<float[]>("sim/flightmodel/engine/ENGN_thro");

// this does the same, but specified an accuracy of 0.3 and a delegate method that should be called automatically whenever the dataref value changes
iface.Subscribe<float[]>("sim/flightmodel/engine/ENGN_thro", 0.3f, (dataRef) =>
{
    Console.WriteLine(string.Format("Dataref changed: {0} = {1}", dataRef.Name, string.Join(",", dataRef.Value)));
});
```

### Getting and setting datarefs
When subscribed to a dataref, you can get and set its value. As seen above you can also observe the value with an event handler.

Getting datarefs is immediate (buffered) - setting dataref values is done asynchronously.

```
// get a dataref
DataRef<float[]> dataRef = iface.GetDataRef<float[]>("sim/flightmodel/engine/ENGN_thro");

// set the value of a dataref
iface.SetDataRef<float[]>(dataRef.Name, new float[] { 1, 1 });
```

## TODO
* Sending commands
* Logging
