import MyDocumento from "./Document";

type MyFolder = {
    folderName: string;
    createdDate: Date;
    documents: MyDocumento[];
}

export default MyFolder;