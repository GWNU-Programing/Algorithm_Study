using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var inputs = Console.ReadLine().Split(' ');  // N 바이트
        int N = int.Parse(inputs[0]);   // 책의 개수
        int M = int.Parse(inputs[1]);   // 한 번에 들 수 있는 책의 개수

        var position = Console.ReadLine().Split(' ').Select(int.Parse).ToList();   // 책의 위치

        // 음수와 양수 좌표로 나누기
        var negative = new List<int>();
        var positive = new List<int>();

        foreach (var pos in position)
        {
            if (pos < 0) negative.Add(pos);
            else positive.Add(pos);
        }

        // 큰 순서로 정렬하기
        negative.Sort();                            // 오름차순
        positive.Sort((a, b) => b.CompareTo(a));    // 내림차순

        int result = 0;

        // 음수 위치 처리
        for (int i = 0; i < negative.Count; i += M)
        {
            // 책을 갔다두고 책을 가지고 가야함 (왕복)
            result += Math.Abs(negative[i]) * 2;   // 절댓값 처리 후 왕복 거리 계산
        }

        // 양수 위치 처리
        for (int i = 0; i < positive.Count; i += M)
        {
            result += positive[i] * 2;   // 왕복 거리 계산
        }

        // 음수와 양수 좌표로 이동하는 경우 가장 먼 곳에서 되돌아오는 거리를 제외
        if (negative.Count > 0 && positive.Count > 0)
        {
            // 음수, 양수 중 가장 먼 곳을 한 번만 이동
            result -= Math.Max(Math.Abs(negative[0]), Math.Abs(positive[0]));
        }
        else if (negative.Count > 0)
        {
            // 음수 중 가장 먼 곳을 한 번만 이동
            result -= Math.Abs(negative[0]);
        }
        else if (positive.Count > 0)
        {
            // 양수 중 가장 먼 곳을 한 번만 이동
            result -= Math.Abs(positive[0]);
        }

        Console.WriteLine(result);   // 최소 걸음 수 출력
    }
}
