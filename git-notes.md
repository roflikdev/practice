# Git notes

## Task 15 — Basic git

### Commands

```bash
git init -b main
git add .
git commit -m "feat: task 15 - init readme"
git switch -c feature/git-basics
git add README.md
git commit -m "feat: task 15 - edit feature"
git switch main
git merge feature/git-basics
# При конфликте: исправить README.md, убрать маркеры конфликта
git add README.md
git commit -m "feat: task 15 - resolve merge conflict"
git log --graph --oneline --all
```

### Output

Локальный учебный пример с настоящим конфликтом и его разрешением:

```text
Auto-merging README.md
CONFLICT (content): Merge conflict in README.md
Automatic merge failed; fix conflicts and then commit the result.

*   627fecb feat: task 15 - resolve merge conflict
|\
| * 91e875c feat: task 15 - edit feature
* | fa333c4 feat: task 15 - edit main
|/
* b864209 docs: task 15 - add notes
* dffeb1b feat: task 15 - init readme
```

В репозитории `practice` также есть учебная ветка `feature/git-basics`
и merge-коммит `29dcfb64` с двумя родителями:
`3e83c0bc` и `e13ea851`.
Это отдельная история коммитов, поэтому SHA в локальном примере другие.

### What I learned

Если две ветки меняют одну строку, Git не может выбрать вариант сам.
Нужно исправить файл и сохранить результат новым коммитом.

## Task 35 — Branches, PR and rebase

### Commands

```bash
git switch -c feature/task-35
git add git-notes.md
git commit -m "docs: task 35 - add git notes"
git push -u origin feature/task-35
# Открыть PR в main и слить его
git switch -c feature/rebase-demo
# Сделать 3 небольших коммита
git rebase -i HEAD~3
git log --oneline
```

### What I learned

Conventional Commits помогают понять историю изменений.
После squash три небольших коммита становятся одним.

### PR link

https://github.com/roflikdev/practice/pull/5

Проверял наличие .gitignore, .editorconfig, README.md и отдельных коммитов заданий.

### Rebase result

В локальном учебном репозитории три небольших коммита были объединены
через `git rebase -i HEAD~3` (два `pick` заменены на `squash`).

Вывод после rebase:

```text
Successfully rebased and updated refs/heads/feature/rebase-demo.
9d54563 docs: task 35 - rebase step 1
627fecb feat: task 15 - resolve merge conflict
fa333c4 feat: task 15 - edit main
91e875c feat: task 15 - edit feature
b864209 docs: task 15 - add notes
```

В GitHub на ветке `feature/rebase-demo` также были созданы три коммита:
`e4b80627`, `3111743c`, `80c1ded5`.
После объединения ветка указывает на один новый коммит `610ceb6a`
(`docs: task 35 - squash rebase demo`).
Это переписанная история, поэтому исходные SHA отличаются от итогового.

### Pull requests

- Уровень 1: https://github.com/roflikdev/practice/pull/3
- Уровень 2: https://github.com/roflikdev/practice/pull/4
- Git-задание 35: https://github.com/roflikdev/practice/pull/5

### Проверка .gitignore

В файле есть правила для `bin/`, `obj/`, `.vs/`, `.idea/`,
`*.user` и `*.suo`. Сборочные каталоги не добавляются в Git.

### Дополнительно: GitHub Actions

Еще попробовал GitHub Actions. Создал простой `.github/workflows/build.yml`,
чтобы GitHub сам запускал `dotnet build` при изменениях, и добавил пару
проверок запуска консольного меню. Сборка прошла без ошибок и предупреждений.
Потом убрал workflow из проекта: это было просто знакомство с возможностью,
а по заданию 35 он не нужен. Эксперимент остался в истории коммитов.


## Task 46 — git stash

В отдельном учебном репозитории изменил `example.txt`, не делая коммит.

### Commands

```bash
git switch -c level-3
git stash
git stash list
git switch main
git switch level-3
git stash pop
git stash list
```

### Output

До `stash pop`:

```text
Saved working directory and index state WIP on level-3: 2e5547a feat: task 46 - base example
stash@{0}: WIP on level-3: 2e5547a feat: task 46 - base example
```

После `stash pop`:

```text
modified: example.txt
Dropped refs/stash@{0} (4b0a9ac8dd39cd25135279169823d9e128542af1)
```

Повторный `git stash list` ничего не вывел. Изменения вернулись в файл.

## Task 47 — git rebase -i

Создал ветку `feature/squash-demo`, сделал четыре небольших коммита, потом объединил их через `git rebase -i HEAD~4`.

### Commands

```bash
git switch -c feature/squash-demo
git log --oneline -5
git rebase -i HEAD~4
git log --oneline -4
```

### Output before

```text
b2dd0de feat: task 47 - step 4
1f44952 feat: task 47 - step 3
86410be feat: task 47 - step 2
2691491 feat: task 47 - step 1
541481c feat: task 46 - restore stashed changes
```

У первого коммита оставил `pick`, у остальных трёх поставил `squash`.

### Output after

```text
Successfully rebased and updated refs/heads/feature/squash-demo.
35a2e07 feat: task 47 - step 1
541481c feat: task 46 - restore stashed changes
2e5547a feat: task 46 - base example
```

Теперь четыре коммита стали одним. На GitHub ветка `feature/squash-demo` содержит итоговый пример одним коммитом `289adbb`.

## Task 48 — git tags

На коммите ветки `main` создал аннотированный тег `v1.0.0`.

### Commands

```bash
git tag -a v1.0.0 -m "Release v1.0.0"
git tag
git show v1.0.0
git push origin v1.0.0
```

### Output

```text
v1.0.0

tag v1.0.0
Release v1.0.0
commit b2b75f31c29421a9f914c6193bbd24c7ba0d8e81
    docs: remove SDK requirement from README
```

Тег создался локально. На GitHub отправить его пока не получилось: при `git push` не было авторизации. Тег ещё нужно отправить из своего Git.

## Task 49 — git reflog

В отдельной учебной ветке сделал коммит, убрал его через `reset`, а потом вернул по хешу из `reflog`.

### Commands

```bash
git reset --hard HEAD~1
git reflog
git reset --hard b6cab6e
git log --oneline
```

### Output

```text
541481c HEAD@{0}: reset: moving to HEAD~1
b6cab6e HEAD@{1}: commit: feat: task 49 - recover this commit

b6cab6e feat: task 49 - recover this commit
541481c feat: task 46 - restore stashed changes
2e5547a feat: task 46 - base example
```

Коммит `b6cab6e` восстановился.

## Task 50 — git bisect

В учебной ветке сделал 11 коммитов с файлом `calculator.txt`. В середине поменял `result=10` на `result=99`.

### Commands

```bash
git bisect start
git bisect bad
git bisect good c959146
# На каждом шаге проверял значение result и ставил good или bad
git bisect reset
```

### Output

```text
Bisecting: 4 revisions left to test after this (roughly 2 steps)
[7528e15] feat: task 50 - step 5
result=99
git bisect bad

Bisecting: 2 revisions left to test after this (roughly 1 step)
[a5ad4e9] feat: task 50 - step 2
result=10
git bisect good

Bisecting: 0 revisions left to test after this (roughly 1 step)
[8e7b3cd] feat: task 50 - step 4
result=10
git bisect good

7528e15aa2c7e45ba28484201fbb6cc1c13cbdaf is the first bad commit
feat: task 50 - step 5
```

После `git bisect reset` вернулся в свою ветку. Коммит с ошибкой найден.
