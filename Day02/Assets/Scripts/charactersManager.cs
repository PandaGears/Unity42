using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactersManager : MonoBehaviour {

	public List<character> charactersList = new List<character>();
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Input.GetKey(KeyCode.LeftControl))
				return;
			foreach (character character in charactersList) {
				character.GetComponent<AudioSource>().clip = character.walkSounds[Random.Range(0, character.walkSounds.Length)];
				character.GetComponent<AudioSource>().Play();

				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit && (hit.collider.gameObject.transform.tag == "orc_town" || hit.collider.gameObject.transform.tag == "orc" || hit.collider.gameObject.transform.tag == "orc_townhall"))
					character.currentEnemyAttacked = hit.collider.gameObject;
				else
					character.currentEnemyAttacked = null;
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				character.changeEndpoint (new Vector3 (mousePosition.x, mousePosition.y, 0));
			} 
		} else if (Input.GetMouseButtonDown(1)) {
			foreach (character character in charactersList) {
					if(character.isSelected)
						character.isSelected = false;
			}
				charactersList.Clear();
		}
	}
}
