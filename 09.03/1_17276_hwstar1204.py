import sys
import copy
input = sys.stdin.readline

t = int(input())
for _ in range(t):
    n,d = map(int,input().split())
    array = [list(map(int,input().split())) for _ in range(n)]
    tmp_array = copy.deepcopy(array)  # 회전한 배열을 저장할 배열

    d = d if d >= 0 else d + 360  # 각도 음수일때 처리 

    for turn in range(d//45):
        for i in range(n):
            for j in range(n):
                if i == j:  # 주 대각선
                    tmp_array[i][j] = array[n//2][j]
                elif i == n//2: # 가운데 행
                    tmp_array[i][j] = array[n-j-1][j]
                elif i+j == n-1: # 부 대각선
                    tmp_array[i][j] = array[i][n//2]
                elif j == n//2: # 가운데 열
                    tmp_array[i][j] = array[i][i]
                else:  # 변하지 않는 부분
                    tmp_array[i][j] = array[i][j]

        array = copy.deepcopy(tmp_array)  # 회전한 배열을 다시 저장

    for a in array:
        print(*a)
