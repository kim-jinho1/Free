using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public ItemInfomation CurrentEquipWeapon; // 아이템을 획득할 때 해당 아이템 정보를 여기에 넣어줍니다.

    public int HP;
    public int Attack;

    public ItemSO EquipWeapon;

    public void EquipItem(int itemID)
    {
        // 여기서 DB에서 ItemID를 Key로 ItemInfomation을 찾을 수 있죠
        //var targetItem = WeaponDB.ItemIDItemSODictionary[itemID]; // 이거를 쓰지 말고

        if(WeaponDB.ItemIDItemSODictionary.TryGetValue(itemID, out var targetItem) == false)
        {
            Debug.LogError($"잘못된 Key {itemID}를 입력하였습니다!");
            // 여기서 서버로 에러 로그 전송하는 코드를 집어넣습니다
            return;
        }

        //EquipWeapon = targetItem;

        /*if(EquipWeapon != null)
        {
            Attack - EquipWeapon
        }
        Attack + targetItem 

           EquipWeapon = targetItem*/

    }

    public bool CompareItemGrade(ItemGrade targetGrade)
    {
        /*if(targetGrade <= EquipWeapon.Grade)
        {
            return true;
        }
        */
        return false;
    }
}
