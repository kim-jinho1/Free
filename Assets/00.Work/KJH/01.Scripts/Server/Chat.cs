using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoSingleton<Chat>
{

	public InputField SendInput;
	public RectTransform ChatContent;
	public Text ChatText;
	public ScrollRect ChatScrollRect;


	public void ShowMessage(string data)
	{
		ChatText.text += ChatText.text == "" ? data : "\n" + data;
		
		Fit(ChatText.GetComponent<RectTransform>());
		Fit(ChatContent);
		Invoke("ScrollDelay", 0.03f);
	}

	private void Fit(RectTransform rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(rect);

	private void ScrollDelay() => ChatScrollRect.verticalScrollbar.value = 0;
}