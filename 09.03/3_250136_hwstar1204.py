"""
1. 그림에서 각 지점마다 dfs 하여 같은덩어리에 해당하는 부분을 고유번호로 설정하여 maps에 표시
2. loafs : 각 집합에 해당하는 크기를 1차원리스트에 저장 
2. 모든 열을 검사 -> set()로 각 집합 추출하고 각 집합에 해당하는 크기의 합이 제일 큰거를 정답으로 
"""
from collections import deque

def solution(land):
    n, m = len(land), len(land[0])  # 세로, 가로
    maps = [[-1]*m for _ in range(n)]  # 각 집합 고유 번호로 표시(+방문표시)
    loafs = [0] * (n*m//2+1)  # 각 집합 고유 번호에 해당하는 덩어리 크기 저장 리스트 
    
    def BFS(x, y, t):
        q = deque([(x,y)])
        maps[x][y] = t
        x, y = [1,0,-1,0], [0,1,0,-1]
        total = 1

        while q:
            nx, ny = q.popleft()
            for mxy in zip(x,y):
                mx, my = nx+mxy[0], ny+mxy[1]
                if 0 <= mx < n and 0 <= my < m and all((land[mx][my], maps[mx][my] == -1)):
                # if 0 <= mx < n and 0 <= my < m and land[mx][my] and maps[mx][my] == -1:
                # if all((0 <= mx < n, 0 <= my < m, land[mx][my], maps[mx][my] == -1)):
                    q.append((mx, my))
                    maps[mx][my] = t
                    total += 1
                    
        return total
    
    loaf_num = 0  # 고유 덩어리 번호 
    for i in range(n):
        for j in range(m):
            if land[i][j] == 0:
                continue
                
            if land[i][j] and maps[i][j] == -1:
                loafs[loaf_num] = BFS(i, j, loaf_num)  # 덩어리 크기 반환
                loaf_num += 1  
                
    answer = 0         
    for teams in list(zip(*maps)): # 열 검사
        tmp = sum([loafs[t] for t in set(teams) if t != -1])  # print(loafs[-1]) -> 0
        answer = max(tmp, answer)
        
    # for m in maps:
    #     print(*m)
    
    return answer


# z = [[0, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 1, 1, 0, 0], [1, 1, 0, 0, 0, 1, 1, 0], [1, 1, 1, 0, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0, 1, 1]]

# result = solution(z)
# print(result)