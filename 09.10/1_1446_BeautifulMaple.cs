using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var inputs = Console.ReadLine().Split(' ');  // N 바이트
        int N = int.Parse(inputs[0]);   // 지름길의 개수
        int D = int.Parse(inputs[1]);   // 고속도록의 길이

        // 시작 위치, 도착 위치, 지름길의 길이
        List<(int start, int end, int length)> shortcuts = new List<(int, int, int)>();

        for (int i = 0; i < N; i++)
        {
            string[] shortcut = Console.ReadLine().Split();
            int start = int.Parse(shortcut[0]);
            int end = int.Parse(shortcut[1]);
            int length = int.Parse(shortcut[2]);
            
            // 고속도로를 넘지 않은 건 추가하기
            if (end <= D)
            {
                shortcuts.Add ((start, end, length));
            }
        }

        // 최대 거리로 초기화하기
        int[] dist = new int[D+1];
        for (int i = 0; i <= D; i++)
        {
            dist[i] = i; // 지름길 사용 안 할 때
        }

        for (int i = 0; i <= D; i++)
        {
            if (i > 0)
            {
                // 도로 위치에서 한 칸 이동하기
                dist[i] = Math.Min(dist[i], dist[i - 1] + 1); // 일반 통행 경우
            }
            // 지름길을 사용하는 경우 갱신
            foreach (var shortcut in shortcuts)
            {
                int start = shortcut.start;
                int end = shortcut.end;
                int length = shortcut.length;

                // i == strat : 현재 위치에서 지름길 사용 가능한가?
                // dist[i] + length는 지름길을 통해 도착 위치(end)까지 이동한 경우의 거리
                if (i == start && dist[i] + length < dist[end])
                {
                    dist[end] = dist[i] + length;
                }
            }
        }
        Console.WriteLine(dist[D]);
    }
}
