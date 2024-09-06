# 시추관이 관통하는 석유 덩어리의 합이 최대가 되는 열을 찾아야 함
# 그때의 석유 덩어리의 총 합을 반환해야 함
# 전체 열 길이만큼의 배열을 만들고 이를 획득한 덩어리의 합으로 사용
# 한 번 탐색할 때마다 덩어리가 위치하는 배열에 합을 하고 해당 덩어리에 대한 방문 표시를 함

from collections import deque

def bfs(land, visited, land_sum, i, j, n, m):
    sum = 1
    max = j
    queue = deque([[i, j]])
    dx = [1, 0] # 맨 왼쪽 열부터 시추하므로 아래, 오른쪽만 확인하면 됨
    dy = [0, 1]

    while queue:
        nx, ny = queue.popleft()
        print(nx, ny)

        for k in range(2):
            mx = nx + dx[k]
            my = ny + dy[k]

            if mx < n and my < m:
                if land[mx][my] == 1 and visited[mx][my] == False:
                    visited[mx][my] = True
                    queue.append([mx, my])
                    sum += 1
                    if my > max: max = my

    for k in range(j, max+1):
        land_sum[k] += sum
    
    print(f"[{i}, {j}], sum: {sum}, max: {max} => {land_sum}")

def solution(land):
    n = len(land)
    m = len(land[0])

    land_sum = [0] * m
    visited = [[False] * m for _ in range(n)]
    
    # 열 기준으로 탐색
    for j in range(m):
        for i in range(n):
            if land[i][j] == 1 and visited[i][j] == False:
                visited[i][j] = True
                bfs(land, visited, land_sum, i, j, n, m)

    return land_sum

land = [[1, 1, 1, 1], [1, 1, 1, 1], [1, 1, 1, 1], [1, 1, 1, 1], [1, 1, 1, 1]]
print(solution(land))