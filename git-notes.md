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
