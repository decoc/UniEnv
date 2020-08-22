# What is UniEnv

UniEnv help you to get/set environment values such as password or token easily without hard coding in Unity project while developing.　This Base idea is [dotnet-env](https://github.com/tonerdo/dotnet-env).

![env](./Images/Env.png)

## Features

- It works `only in Editor` to avoid that products include env file
- Env object suggest that `writing env path to .gitignore`
- You can write env settings directory as simple format texts as following

```.env
Key1=Value1
Key2=Value2
Key3=Value3
```

## How to Use

1. Open Env.asset under Plugins/UniEnv
2. Press `"+"` button to add new key value pairs of enviroment values
3. Get environment values from scripts as following

```cs
public void ReadFormValue(){
    var userId = UniEnv.Config["userId"];
    var password = UniEnv.Config["password"];
}
```

or

```cs
public void ReadFormValue(){
    var userId = UniEnv.Config.GetString("userId");
    var password = UniEnv.Config.GetString("password");
}
```

# UPM Package

You can add `https://github.com/decoc/UniEnv.git?path=Assets/Plugins` to Package Manager

## Licenses
This project is licensed under the MIT License - see the [LICENSE.txt](./LICENSE.txt) file for details.

## Dependencies

This library depends on [UnitySerializedDictionary](https://github.com/Prastiwar/UnitySerializedDictionary) to manage key-value pairs in Unity. In the future update, it may be remove due to official support serializable dictionary. [See more](https://forum.unity.com/threads/dictionary-serialization.915947/)
