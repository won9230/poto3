using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 해상도 관련 (기본 1920 * 1080)
/// </summary>
public class CameraResolution : MonoBehaviour
{
	private void Awake()
	{
		Camera camera = GetComponent<Camera>();
		Rect rect = camera.rect;
		float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9); //가로가 더 남는지 세로가 더 남는지 검사
		float scaleWidth = 1f / scaleHeight;
		if(scaleHeight < 1) //세로가 더 길면 조정
		{
			rect.height = scaleHeight;
			rect.y = (1f - scaleHeight) / 2f;
		}
		else //가로가 더 길면 조정
		{
			rect.width = scaleWidth;
			rect.x = (1f - scaleWidth) / 2f;
		}
		camera.rect = rect;
	}
	//void OnpreCull() => GL.Clear(true,true,Color.black); //뭔지 몰라서 주석처리
}
