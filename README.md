# ASP.NET CORE 项目
> 项目介绍

[TOC]

## 使用的组件
1. Newtonsoft.Json
> Serialize JSON

```C#
Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Sizes = new string[] { "Small" };

string json = JsonConvert.SerializeObject(product);
// {
//   "Name": "Apple",
//   "Expiry": "2008-12-28T00:00:00",
//   "Sizes": [
//     "Small"
//   ]
// }
```
> Deserialize JSON

```C#
string json = @"{
  'Name': 'Bad Boys',
  'ReleaseDate': '1995-4-7T00:00:00',
  'Genres': [
    'Action',
    'Comedy'
  ]
}";

Movie m = JsonConvert.DeserializeObject<Movie>(json);

string name = m.Name;
// Bad Boys
```
> LINQ to JSON

```C#
JArray array = new JArray();
array.Add("Manual text");
array.Add(new DateTime(2000, 5, 23));

JObject o = new JObject();
o["MyArray"] = array;

string json = o.ToString();
// {
//   "MyArray": [
//     "Manual text",
//     "2000-05-23T00:00:00"
//   ]
// }
```
> Parse JSON Schema from JSON
```C#
 1 string schemaJson = @"{
 2  'description': 'A person',
 3  'type': 'object',
 4  'properties': {
 5    'name': {'type':'string'},
 6    'hobbies': {
 7      'type': 'array',
 8      'items': {'type':'string'}
 9    }
10  }
11 }";
12
13 JSchema schema = JSchema.Parse(schemaJson);
14
15 Console.WriteLine(schema.Type);
16 // Object
17
18 foreach (var property in schema.Properties)
19 {
20    Console.WriteLine(property.Key + " - " + property.Value.Type);
21 }
22 // name - String
23 // hobbies - Array
```
>Load JSON Schema from a file

```C#
1 // read file into a string and parse JSchema from the string
2 JSchema schema1 = JSchema.Parse(File.ReadAllText(@"c:\schema.json"));
3
4 // load JSchema directly from a file
5 using (StreamReader file = File.OpenText(@"c:\schema.json"))
6 using (JsonTextReader reader = new JsonTextReader(file))
7 {
8    JSchema schema2 = JSchema.Load(reader);
9 }
```
2. Microsoft.AspNetCore.Session
> 使用Session在Startup.cs进行配置
```C#
 services.AddDistributedMemoryCache();
 services.AddSession(options =>
 {
    options.CookieName = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
 });
```
> Configure中添加使用session
```C#
 app.UseSession();
```
> 使用session
```C#
//设置session
HttpContext.Session.SetInt32("_key", 12);
HttpContext.Session.SetString("_name", "jswei30");
//获取session
HttpContext.Session.GetInt32("_key");
HttpContext.Session.GetString("_name");
```

3. Microsoft.Extensions.Caching.Redis
> 使用Redis在ConfigureServices中配置

```C#
// Redis implementation of IDistributedCache.
// This will override any previously registered IDistributedCache service.
services.AddSingleton<IDistributedCache, RedisCache>();
```