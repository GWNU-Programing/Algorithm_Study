// https://www.acmicpc.net/problem/17276
// 백준 17276 (백준)
// 3번 째 케이스 (최종)
/*
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 표준 입력을 BufferedStream으로 감싸서 입력 성능 향상
        BufferedStream bufferedInput = new BufferedStream(Console.OpenStandardInput());
        StreamReader sr = new StreamReader(bufferedInput);
        {
            // 표준 출력을 BufferedStream으로 감싸서 출력 성능 향상
            using (BufferedStream bufferedOutput = new BufferedStream(Console.OpenStandardOutput()))
            using (StreamWriter sw = new StreamWriter(bufferedOutput))
            {
                int T = int.Parse(sr.ReadLine());  // 테스트 케이스 수 입력 받기
                for (int t = 0; t < T; t++)
                {
                    // 배열 크기와 회전 각도 입력 받기
                    string[] firstLine = sr.ReadLine().Split();
                    int n = int.Parse(firstLine[0]); // 배열의 크기 (n x n)
                    int d = int.Parse(firstLine[1]); // 회전 각도

                    // 배열 X 입력 받기
                    int[,] X = new int[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        string[] row = sr.ReadLine().Split();
                        for (int j = 0; j < n; j++)
                        {
                            X[i, j] = int.Parse(row[j]); // 배열의 각 요소 입력 받기
                        }
                    }

                    // 회전 각도 최적화
                    d = d % 360; // 각도를 360도로 나눈 나머지로 변환
                    if (d < 0) d += 360; // d가 음수인 경우 양수로 변환

                    int rotationCount = d / 45; // 회전 횟수 계산

                    // 회전이 필요한 경우에만 회전 수행
                    if (rotationCount > 0)
                    {
                        X = Rotate(X, n, rotationCount); // 회전 수행
                    }

                    // 결과 출력
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            sw.Write(X[i, j] + " "); // 배열의 각 요소 출력
                        }
                        sw.WriteLine();
                    }
                    sw.Flush(); // 버퍼를 비워서 즉시 출력
                }
            }
        }
    }

    // 45도 시계 방향으로 회전하는 함수
    static int[,] Rotate(int[,] X, int n, int rotationCount)
    {
        int[,] result = (int[,])X.Clone(); // 배열을 복사하여 결과 배열 초기화
        for (int r = 0; r < rotationCount; r++)
        {
            int[] tempDiagonal = new int[n]; // 주 대각선 요소 저장용 배열
            int[] tempMiddleColumn = new int[n]; // 중간 열 요소 저장용 배열
            int[] tempAntiDiagonal = new int[n]; // 부 대각선 요소 저장용 배열
            int[] tempMiddleRow = new int[n]; // 중간 행 요소 저장용 배열

            // 주 대각선 -> 중간 열로 이동
            for (int i = 0; i < n; i++)
            {
                tempMiddleColumn[i] = X[i, i];
            }

            // 중간 열 -> 부 대각선으로 이동
            for (int i = 0; i < n; i++)
            {
                tempAntiDiagonal[i] = X[i, n / 2];
            }

            // 부 대각선 -> 중간 행으로 이동
            for (int i = 0; i < n; i++)
            {
                tempMiddleRow[i] = X[n - i - 1, i];
            }

            // 중간 행 -> 주 대각선으로 이동
            for (int i = 0; i < n; i++)
            {
                tempDiagonal[i] = X[n / 2, i];
            }

            // 결과 배열에 회전된 값 업데이트
            for (int i = 0; i < n; i++)
            {
                result[i, n / 2] = tempMiddleColumn[i]; // 중간 열 업데이트
                result[i, n - i - 1] = tempAntiDiagonal[i]; // 부 대각선 업데이트
                result[n / 2, i] = tempMiddleRow[i]; // 중간 행 업데이트
                result[i, i] = tempDiagonal[i]; // 주 대각선 업데이트
            }

            // 다음 회전을 위해 배열을 복사
            X = (int[,])result.Clone();
        }

        return result; // 회전된 배열 반환
    }
}
*/
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
