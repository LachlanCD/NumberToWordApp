interface ErrorMessageProps {
  error: boolean;
}

const ErrorMessage = ({ error }: ErrorMessageProps) => {
  if (!error) return null;

  return (
    <p className="mt-4 text-red-400 text-center"> An Error Occured </p>
  );
};

export default ErrorMessage;

