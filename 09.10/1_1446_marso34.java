import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int N = Integer.parseInt(st.nextToken()); // 지름길의 수 (0 < N <= 12)
        int D = Integer.parseInt(st.nextToken()); // 고속도로의 길이 (0 < D <= 10,000)

        int[][] arr = new int[N][3]; // 시작 위치, 도착 위치, 지름길의 길이 (위치, 길이는 0 < x <= 10,000)

        // 입력
        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(br.readLine());
            arr[i][0] = Integer.parseInt(st.nextToken()); // 시작 위치
            arr[i][1] = Integer.parseInt(st.nextToken()); // 도착 위치
            arr[i][2] = Integer.parseInt(st.nextToken()); // 길이
        }

        int[] dp = new int[D + 1];

        // 초기화
        for (int i = 0; i <= D; i++) {
            dp[i] = i;
        }

        for (int i = 1; i <= D; i++) {
            dp[i] = Math.min(dp[i], dp[i - 1] + 1);

            for (int j = 0; j < N; j++) {
                if (i == arr[j][1]) {
                    dp[i] = Math.min(dp[i], dp[arr[j][0]] + arr[j][2]);
                }
            }
        }

        System.out.println(dp[D]);
    }
}