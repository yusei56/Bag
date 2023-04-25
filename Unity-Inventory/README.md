# Unity-
## 1.背包系统
### 道具数据：Item
ScriptableObject，用来存储道具数据。<br>
道具的数据变量有：<br>
id(int)：道具编号<br>
itemId(int)：道具专属的id<br>
itemType(int)：道具类型，决定道具所属背包<br>
itemName(string)：道具名<br>
itemInfo(string)：道具描述<br>
itemImage(Sprite):道具图片<br>
itemNum(int)：道具持有数<br>
New(bool):确认道具是否为第一次获得的<br>

### 背包数据：Inventory
ScriptableObject，用来存储背包里的道具数据。<br>
背包的数据变量有：<br>
itemList(List<Item>)：存储背包里的道具数据<br>
itemOrderList(Dictionary<int, Item>)：存储背包里的道具数据,使用id作为key方便排序<br>

### 道具数据的添加：ItemOnWorld
将这个Script添加到道具Object上，当玩家触碰到道具时将调用这个Script里的OnTrigger函数。然后调用AddNewItem函数将道具的数据添加到Inventory ScriptableObject里List来存储数据。根据int参数来决定将道具存储到哪个Inventory（背包）里。使用item.itemType作为输入参数。暂定有四个背包来存储不同类型的道具。

### 道具显示：Slot
控制单个道具在背包的显示组件，以及其作为按钮的功能。

### 背包道具管理： InventoryManager,InventoryManager_2,InventoryManager_3,InventoryManager_4
InventoryManager控制背包1里所持道具的显示。道具数据来自New Inventory里的itemOrderList。通过CreateNewItem函数生成Slot类添加到背包UI里。RefrenshItem函数调用CreateNewItem函数，来更新刷新背包里的道具显示。包括道具数量和新道具等显示的刷新。要在其他Script里调用时：
```
InventoryManager.RefrenshItem();
```
InventoryManager_2控制背包2里所持道具的显示。道具数据来自New Inventory 2里的itemOrderList。其他同上。要在其他Script里调用时：

```
InventoryManager_2.RefrenshItem();
```

InventoryManager_3控制背包3里所持道具的显示。道具数据来自New Inventory 3里的itemOrderList。其他同上。要在其他Script里调用时：

```
InventoryManager_3.RefrenshItem();
```

InventoryManager_4控制背包4里所持道具的显示。道具数据来自New Inventory 4里的itemOrderList。其他同上。要在其他Script里调用时：

```
InventoryManager_4.RefrenshItem();
```

