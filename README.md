# Change FOV in [Firewatch](http://www.firewatchgame.com/) [![Build status](https://ci.appveyor.com/api/projects/status/k73av165njrmowf9/branch/master?svg=true)](https://ci.appveyor.com/project/beatcracker/firewatch-fov-changer/branch/master)

![Firewatch FOV Changer](img/FirewatchFOVChanger.png)

Download executable file in [Releases](https://github.com/beatcracker/firewatch-fov-changer/releases) section.

# Command line usage

## Arguments

* `FOV` - required FOV (55 - 110)
* `-s` - silent. Don't show message after FOV is set.

## Example

### Set FOV to 75


```
FirewatchFOVChanger.exe 75 -s

```

### Set FOV to 75, silently.


```
FirewatchFOVChanger.exe 75 -s

```

# Details

Default FOV in Firewatch is `55`, which is quite low for the most of the users. This app allows you to change FOV by modifying Firewatch settings in registry.

You can also [do this manually](http://steamcommunity.com/app/383870/discussions/1/412446292776350214):

* Open up the registry editor by typing `regedit.exe` into your Windows search bar. 

* Navigate your registry to the following key:
  `HKEY_CURRENT_USER\Software\CampoSanto\Firewatch\fovAdjust_h2041137991`

* Right click on `fovAdjust_h2041137991` and choose `Modify`. Set the base to be `Decimal`.

* Set the value to be `100` times the amount you want to adjust the FOV by. For example, if you wanted the FOV to be `90` you need to increase the FOV by `35`. So the value of `fovAdjust_h2041137991` should be `3500` (35 * 100).
