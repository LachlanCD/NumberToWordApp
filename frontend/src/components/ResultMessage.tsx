interface ResultProps {
  result: string;
}

const Result = ({ result }: ResultProps) => {
  if (!result) return null;

  return (
    <p className="mt-4 text-center">
      <strong>Result:</strong> {result}
    </p>
  );
};

export default Result;
