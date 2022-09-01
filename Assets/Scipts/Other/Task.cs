using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : BaseManager<Task>
{
   public List<ItemType> taskList = GameManager.GetInstance().mintApple.GetList();
}
