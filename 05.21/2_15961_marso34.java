import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.StringTokenizer;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int n = Integer.parseInt(st.nextToken()); // 접시의 수
        int d = Integer.parseInt(st.nextToken()); // 초밥의 가짓수
        int k = Integer.parseInt(st.nextToken()); // 연속해서 먹는 접시의 수
        int c = Integer.parseInt(st.nextToken()); // 쿠폰 번호

        int[] arr = new int[n];
        int[] visited = new int[d+1];

        int cnt = 0;
        int max = 0; // 초밥 가짓수의 최댓값

        for (int i = 0; i < n; i++) {
            arr[i] = Integer.parseInt(br.readLine());
        } // 여기까지 입력

        for (int i = 0; i < n; i++) {
            /* 이 방법을 사용하면 시간 초과
            for (int j = i; j < i + k; j++) {
                // 원형 리스트 처럼 사용하기 위해서
                int temp = j >= n ? j - n : j;

                // arr[tmep]로 중복 제거해서 먹은 개수 세기        
            }
            */

            if (i == 0) { // 처음 0일 때만 초기값
                for (int j = 0; j < k; j++) {
                    if (visited[arr[j]] == 0) {
                        cnt++;
                    } 

                    visited[arr[j]]++;
                } 

                max = cnt;
                continue;
            }
            
            // 맨 앞 제거
            if (visited[arr[i-1]] == 1) {
                cnt--;
            }
            
            visited[arr[i-1]]--;

            // 뒤에 하나 추가, 원형 리스트 처럼 사용하기 위해서 temp 사용
            int temp = (i + k - 1) >= n ? (i + k -1) - n : (i + k -1);

            if (visited[arr[temp]] == 0) {
                cnt++;
            }

            visited[arr[temp]]++;

            if (max <= cnt) {
                if (visited[c] == 0) {
                    max = cnt + 1;
                } else {
                    max = cnt;
                }
            }
        }

        System.out.println(max);
    }
}