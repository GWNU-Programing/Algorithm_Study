import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.Arrays;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int N = Integer.parseInt(st.nextToken()); // 책의 개수 (0 < N <= 50)
        int M = Integer.parseInt(st.nextToken()); // 한 번에 들 수 있는 책의 개수 (0 < N <= 50)

        int[] arr = new int[N]; // 책의 위치
        int index = 0, sum = 0;

        // 입력
        for (String str : br.readLine().split(" ")) {
            arr[index] = Integer.parseInt(str);
            index++;
        }

        Arrays.sort(arr); // 오름차순 정렬

        index = arr[0] + arr[N-1] < 0 ? 0 : N-1; // 왼쪽 책의 위치가 0에 더 가까우면 0, 오른쪽 책의 위치가 0에 더 가까우면 N-1

        for (int i = N-1; 0 <= i; i-= M) {
            if (arr[i] > 0)
                sum += arr[i] * 2;
        }

        for (int i = 0; i < N; i+= M) {
            if (arr[i] < 0)
                sum += Math.abs(arr[i]) * 2;
        }

        System.out.println(sum - Math.abs(arr[index]));
    }
}