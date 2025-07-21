import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen text-center px-4">
      <h1 className="text-6xl font-extrabold text-stone-100 mb-4">
        404 - Page Not Found
      </h1>
      <p className="text-2xl text-stone-600 dark:text-stone-300 mb-8">
        Sorry, I don&apos;t know how you got here, but the page does not exist.
      </p>
      <Link
        to="/"
        className="px-6 py-3 bg-stone-800 text-white rounded-lg text-lg font-medium shadow hover:bg-stone-700 transition transform hover:scale-115"
      >
        Return Home
      </Link>
    </div>
  );
};

export default NotFound;

