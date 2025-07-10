import express, { Request, Response } from "express";

const app = express();

interface User {
  username: string;
  password: string;
}

// adding in-memory user, will migrate to a db later
let users: User[] = [];

function freeze<const T>(value: T): T {
  return Object.freeze(value);
}

app.post("/api/v1/users/register", (req: Request, res: Response) => {
  const { username, password } = req.body;

  if (!username || !password) {
    res.status(400).json({
      success: false,
      message: "Username and password are required.",
    });
    return;
  }

  try {
    const existingUser = users.find((user) => user.username === username);

    if (existingUser) {
      res.status(404).json({
        success: false,
        message: "Username already exists.",
      });
      return;
    }

    users.push({ username, password });

    res.status(201).json({
      success: true,
      message: "User registered successfully.",
    });
  } catch (err) {
    console.error("Something went wrong.", err);
    res.status(500).json({
      success: false,
      message: "Something went wrong.",
    });
    return;
  }
});

const PORT = 5000;
app.listen(4000, () => {
  console.log(`App is listening on PORT 4000`);
});
