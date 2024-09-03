// https://www.acmicpc.net/problem/17276
// 백준 17276 (백준)
// 3번 째 케이스 (최종)
using System;

public class Program
{
    public static void Main()
    {
        // 테스트 케이스의 수를 입력받음
        int T = int.Parse(Console.ReadLine());

        // T개의 테스트 케이스를 처리
        while (T-- > 0)
        {
            // 첫 번째 줄 입력 (n: 행렬의 크기, d: 회전 각도)
            string[] firstLine = Console.ReadLine().Split();
            int n = int.Parse(firstLine[0]);
            int d = int.Parse(firstLine[1]);

            // n x n 크기의 행렬을 초기화하고 값을 입력받음
            int[,] X = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    X[i, j] = int.Parse(row[j]);
                }
            }

            // 행렬을 d도 만큼 회전시킴
            RotateMatrix(X, d);

            // 회전된 행렬을 출력
            PrintX(X);
        }
    }

    // 행렬을 d도 만큼 회전시키는 함수
    private static void RotateMatrix(int[,] X, int d)
    {
        int n = X.GetLength(0);
        // d도를 45도로 나눈 후 나머지 값을 이용해 몇 번 회전해야 하는지 계산
        int rotations = ((d % 360) / 45 + 8) % 8;

        // 필요한 횟수만큼 45도씩 시계 방향으로 회전
        for (int i = 0; i < rotations; i++)
        {
            RotateClockwise(X);
        }
    }

    // 행렬을 45도 시계 방향으로 회전시키는 함수
    private static void RotateClockwise(int[,] X)
    {
        int n = X.GetLength(0);
        int mid = n / 2; // 행렬의 중앙 인덱스

        // 행렬의 주요 대각선, 중앙 열, 반대 대각선, 중앙 행을 저장할 배열
        int[] mainDiagonal = new int[n];
        int[] centerColumn = new int[n];
        int[] antiDiagonal = new int[n];
        int[] centerRow = new int[n];

        // 각 배열에 값을 저장
        for (int i = 0; i < n; i++)
        {
            mainDiagonal[i] = X[i, i];
            centerColumn[i] = X[i, mid];
            antiDiagonal[i] = X[n - i - 1, i];
            centerRow[i] = X[mid, i];
        }

        // 45도 회전 후 값을 다시 행렬에 배치
        for (int i = 0; i < n; i++)
        {
            X[i, i] = centerColumn[i];         // 중앙 열 -> 주요 대각선
            X[i, mid] = antiDiagonal[i];       // 반대 대각선 -> 중앙 열
            X[n - i - 1, i] = centerRow[i];    // 중앙 행 -> 반대 대각선
            X[mid, i] = mainDiagonal[i];       // 주요 대각선 -> 중앙 행
        }
    }

    // 행렬을 출력하는 함수
    private static void PrintX(int[,] X)
    {
        int n = X.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j > 0) Console.Write(" "); // 각 요소 사이에 공백 추가
                Console.Write(X[i, j]);
            }
            Console.WriteLine(); // 한 행이 끝나면 줄 바꿈
        }
    }
}

/*
2번 케이스
출력값이랑 근접해진 코드
using System;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            string[] inputs = Console.ReadLine().Split();
            int N = int.Parse(inputs[0]);
            int d = int.Parse(inputs[1]);

            int[,] X = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    X[i, j] = int.Parse(inputs[j]);
                }
            }

            int[,] temp = new int[N, N];

            if (d < 0)
            {
                // 반시계방향
                d += 360;
            }

            if (d == 360 || d == 0)
            {
                PrintBoard(X, N);
            }
            else
            {
                for (int rotation = 0; rotation < d / 45; rotation++)
                {
                    int mid = N / 2;

                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            // 1. 주 대각선 -> 가운데 열
                            if (j == mid)
                            {
                                temp[i, j] = X[i, i];
                            }
                            // 2. 가운데 열 -> 부 대각선
                            else if (i + j == N - 1)
                            {
                                temp[i, j] = X[i, mid];
                            }
                            // 3. 부 대각선 -> 가운데 행
                            else if (i == mid)
                            {
                                temp[i, j] = X[N - j - 1, j];
                            }
                            // 4. 가운데 행 -> 주 대각선
                            else if (i == j)
                            {
                                temp[i, j] = X[mid, j];
                            }
                            else
                            {
                                temp[i, j] = X[i, j];
                            }
                        }
                    }

                    // Copy temp to X
                    Array.Copy(temp, X, X.Length);
                }

                PrintBoard(temp, N);
            }
        }
    }

    static void PrintBoard(int[,] X, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j > 0) Console.Write(" ");
                Console.Write(X[i, j]);
            }
            Console.WriteLine();
        }
    }
}
*/
/*
1번 케이스
정답이랑 매우 먼 케이스
using System;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine()); // 테스트 케이스 수

        for (int t = 0; t < T; t++)
        {
            string[] firstLine = Console.ReadLine().Split();
            int n = int.Parse(firstLine[0]);
            int d = int.Parse(firstLine[1]);

            // 정수 배열 X
            int[,] X = new int[n, n];

            // 배열 입력 받기
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    X[i, j] = int.Parse(row[j]);
                }
            }

            // 각도에 따라 회전하기
            int times = (d / 45) % 8;

            for (int i = 0; i < Math.Abs(times); i++)
            {
                if(times > 0)
                {
                    Rotate45ClockWise(X, n);
                }
                else
                {
                    Rotate45Counterclockwise(X, n);
                }
            }
            // 배열 출력하기
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(X[i, j]);
                    if (j < n - 1) // 숫자가 들어간 후 공백을 넣어주는 조건
                        Console.Write(" "); // 각 숫자 사이에 공백 추가
                }
                Console.WriteLine(); // 각 행 출력 후 줄 바꿈
            }
        }
    }


    private static void Rotate45ClockWise(int[,] x, int n)
    {
        // 중앙 찾기
        int mid = n / 2;

        // 임시 저장소 생성하기
        int[] tempDiag = new int[n];        // 주 대각선 
        int[] tempRow = new int[n];             // 가운데 행
        int[] tempAntiDiag = new int[n];    // 부 대각선
        int[] tempColumn = new int[n];          // 가운데 열

        for (int i = 0; i < n; i++)
        {
            tempDiag[i] = x[i, i];              // 주 대각선 저장
            tempRow[i] = x[mid, i];             // 가운데 행 저장
            tempAntiDiag[i] = x[n - 1 - i, i];  // 부 대각선 저장
            tempColumn[i] = x[i, mid];          // 가운데 열 저장
        }

        // 회전
        for (int i = 0; i < n; i++)
        {
            x[i, mid] = tempDiag[i];        // 주 대각선 -> 가운데 열
            x[n - 1 - i, i] = tempColumn[i];    // 가운데 열 -> 부 대각선
            x[mid, i] = tempAntiDiag[i];    // 부 대각선 -> 가운데 행
            x[i, i] = tempRow[i];               // 가운데 행 -> 주 대각선
        }
    }
    private static void Rotate45Counterclockwise(int[,] x, int n)
    {
        // 중앙 찾기
        int mid = n / 2;

        // 임시 저장소 생성하기
        int[] tempDiag = new int[n];            // 주 대각선 
        int[] tempRow = new int[n];             // 가운데 행
        int[] tempAntiDiag = new int[n];        // 부 대각선
        int[] tempColumn = new int[n];          // 가운데 열

        for (int i = 0; i < n; i++)
        {
            tempDiag[i] = x[i, i];              // 주 대각선 저장
            tempRow[i] = x[mid, i];             // 가운데 행 저장
            tempAntiDiag[i] = x[n - 1 - i, i];  // 부 대각선 저장
            tempColumn[i] = x[i, mid];          // 가운데 열 저장
        }

        // 회전
        for (int i = 0; i < n; i++)
        {
            x[i, mid] = tempDiag[i];            // 주 대각선 -> 가운데 열
            x[n - 1 - i, i] = tempColumn[i];    // 가운데 열 -> 부 대각선
            x[mid, i] = tempAntiDiag[i];        // 부 대각선 -> 가운데 행
            x[i, i] = tempRow[i];               // 가운데 행 -> 주 대각선
        }

    }
}
*/
